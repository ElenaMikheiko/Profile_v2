using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Model.Infrastructure;
using Profile.Web.ViewModels.AdminViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Profile.Web.Extensions;
using Profile.Web.ViewModels;
using Profile.Service.Services.Interfaces;
using Profile.Service.Services;

namespace Profile.Web.Controllers
{
    [Authorize(Roles = ProfilerRoles.Admin)]
    public class AdminController : Controller
    {
        private ProfileDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private IResumeService _resumeService;
        private IStreamService _streamService;
        private IStudentService _studentService;
        private ITrainerService _trainerService;
        private IUserInfoService _userInfoService;

        #region constructor
        //import IConfiguration to be able to read data from appsettings.json
        public AdminController(
            ProfileDbContext db, 
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager, 
            IResumeService resumeService,
            IStreamService streamService, 
            IStudentService studentService,
            ITrainerService trainerService,
            IUserInfoService userInfoService)
        {
            _db = db;
            _configuration = configuration;
            _userManager = userManager;
            _resumeService = resumeService;
            _studentService = studentService;
            _streamService = streamService;
            _trainerService = trainerService;
            _userInfoService = userInfoService;
        }
        #endregion
 
        [HttpPost]
        public async Task<IActionResult> ImportApiKey(string apiKey)
        {
            //get current user
            ApplicationUser loggedUser = await GetUserAsync();
            UserInfo userInfo = _userInfoService.GetUserInfo(loggedUser?.Email);

            if (userInfo != null)
            {
                //write api key
                userInfo.GoogleApiKey = apiKey;
            }

            try
            {
                //update database
                await _userInfoService.SaveUserInfoAsync(userInfo);

                return RedirectToAction("ImportAccounts");
            }
            catch(Exception ex)
            {
                //TODO: handle the exception
            }

            //TODO: add error message
            return View("ImportApiKey");

        }

        [HttpGet]
        public async Task<IActionResult> ImportAccounts()
        {
            //get current user
            ApplicationUser loggedUser = await GetUserAsync();

            //compare if it's userinfo contains googleApiKey
            if (_userInfoService.GetUserInfo(loggedUser?.Email).GoogleApiKey == null)
            {
                return View("ImportApiKey");
            }

            ImportAccountsViewModel viewModel = new ImportAccountsViewModel();

            await PopulateViewModel(viewModel);
            
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ImportTrainerAccounts(ImportAccountsViewModel viewModel)
        {
            //Keep track of added users
            //Use this vars to minimize database quering
            Dictionary<String, String> generatedPasswords = new Dictionary<string, string>();
            List<ApplicationUser> usersToNotify = new List<ApplicationUser>();
            List<UserInfo> userInfosToNotify = new List<UserInfo>();

            string spreadsheetId = "";
            try
            {
                //break the link and extrach the id
                spreadsheetId = viewModel.ApiKey.Split(new[] { '/' })[5];
            }
            catch
            {
                ModelState.AddModelError("WrongLink", "There was an issue processing your request. Please verify the link you are pasting are from a google spreadsheet.");
                await PopulateViewModel(viewModel);
                return View("ImportAccounts", viewModel);
            }

            //get the api key
            ApplicationUser loggedUser = await GetUserAsync();

            //Define the web request params
            string sheetRange = "A2:Z";
            string apiKey = _userInfoService.GetUserInfo(loggedUser?.Email).GoogleApiKey;
            string requestUrl = "https://sheets.googleapis.com/v4/spreadsheets/" + spreadsheetId + "/values/" + sheetRange + "?key=" + apiKey;

            //create request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                //read the response stream
                StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                var jsonString = reader.ReadToEnd();

                //parse the response stream
                JObject deserealizedJson = JsonConvert.DeserializeObject(jsonString) as JObject;
                IEnumerable<JToken> tableRows = deserealizedJson.GetSheetRow(2);

                //check if the spreadsheet contains duplicate emails
                List<string> ssEmails = new List<string>();
                foreach (JToken row in tableRows)
                {
                    ssEmails.Add(row.GetElementValue(2));
                }
                if (ssEmails.Count != ssEmails.Distinct().Count())
                {
                    ModelState.AddModelError("DuplicateEmails", "It seems that the Google table contains duplicate emails. Please check the table and try again.");
                    await PopulateViewModel(viewModel);
                    return View("ImportAccounts", viewModel);
                }

                //get teh list of current trainers' emails in the database
                IList<string> databaseTrainerEmails = _trainerService.GetTrainerEmailsByRoleName(ProfilerRoles.Trainer);

                //check if a email is already present in the system
                foreach (JToken row in tableRows)
                {
                    string sheetRowEmail = row.GetElementValue(2);

                    if (!databaseTrainerEmails.Contains(sheetRowEmail))
                    {
                        //pick values from the spreadsheet for the new user
                        ApplicationUser user = new ApplicationUser() { UserName = sheetRowEmail, Email = sheetRowEmail };

                        //generate a password
                        string password = PasswordGenerator.Generate(6, 0);

                        var result = await _userManager.CreateAsync(user, password);
                        if (result.Succeeded)
                        {
                            //add to the dictionary (for testing only)
                            generatedPasswords.Add(user.UserName, password);

                            //add to the role Trainers
                            var currentUser = await _userManager.FindByNameAsync(user.UserName);
                            await _userManager.AddToRoleAsync(currentUser, ProfilerRoles.Trainer);

                            //add user info
                            //TODO: parse the number
                            UserInfo userInfo = new UserInfo
                            {
                                UserId = currentUser.Id,
                                EnName = row.GetElementValue(0),
                                EnSurname = row.GetElementValue(1),
                                Email = row.GetElementValue(2),
                                Phone = row.GetElementValue(3)
                            };

                            await _userInfoService.AddUserInfoAsync(userInfo);

                            //bind userInfo to applicationUser
                            currentUser.UserInfo = userInfo;

                            //keep track of the new email
                            usersToNotify.Add(currentUser);
                            userInfosToNotify.Add(userInfo);
                        }
                    }
                }

                try
                {
                    //save changes to the database
                    _db.SaveChanges();
                }
                catch
                {
                    ModelState.AddModelError("Import failed", "Server error: can’t create new accounts. Please try again later.");
                    await PopulateViewModel(viewModel);
                    return View("ImportAccounts", viewModel);
                }
            }

            ////send emails
            //foreach (ApplicationUser userToNotify in usersToNotify)
            //{
            //    UserInfo thisUserInfo = userInfosToNotify.FirstOrDefault(x => x.UserId == userToNotify.Id);
            //    string userPassword = generatedPasswords.FirstOrDefault(x => x.Key == userToNotify.Email).Value;
            //    string appLink = _configuration.GetSection("ProfileAppLink").Value;

            //    EmailSender emailSender = new EmailSender();
            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine("Здравствуйте, " + thisUserInfo.RuName + " " + thisUserInfo.RuSurname + ".");
            //    sb.AppendLine("");
            //    sb.AppendLine("Для вас была создана учетная запись в системе PROFILE.");
            //    //sb.AppendLine("Please use this link: " + appLink + " and this password: " + userPassword + " to log in to your account.");
            //    sb.AppendLine("Для входа в систему используйте ваш пароль - " + userPassword);
            //    await emailSender.SendEmailAsync(userToNotify.Email, "Данные вашей учетной записи в Системе PROFILE Образовательного центра ПВТ", sb.ToString());
            //}

            return View("ImportAccountsResult", generatedPasswords);
        }

        [HttpPost]
        public async Task<IActionResult> ImportStudentAccounts(ImportAccountsViewModel viewModel)
        {

            //Keep track of added users
            //Use this vars to minimize database quering
            Dictionary<String, String> generatedPasswords = new Dictionary<string, string>();
            List<ApplicationUser> usersToNotify = new List<ApplicationUser>();
            List<UserInfo> userInfosToNotify = new List<UserInfo>();

            string spreadsheetId = "";
            try
            {
                //break the link and extrach the id
                spreadsheetId = viewModel.ApiKey.Split(new[] { '/' })[5];
            }
            catch
            {
                ModelState.AddModelError("WrongLink", "There was an issue processing your request. Please verify the link you are pasting are from a google spreadsheet.");
                await PopulateViewModel(viewModel);
                return View("ImportAccounts", viewModel);
            }

            //get the api key
            ApplicationUser loggedUser = await GetUserAsync();

            //Define the web request params
            string sheetRange = "A2:Z";
            string apiKey = _userInfoService.GetUserInfo(loggedUser?.Email).GoogleApiKey;
            string requestUrl = "https://sheets.googleapis.com/v4/spreadsheets/" + spreadsheetId + "/values/" + sheetRange + "?key=" + apiKey;

            //create request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                //read the response stream
                StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                var jsonString = reader.ReadToEnd();

                //parse the response stream
                JObject deserealizedJson = JsonConvert.DeserializeObject(jsonString) as JObject;
                IEnumerable<JToken> tableRows = deserealizedJson.GetSheetRow(2);

                //check if the spreadsheet contains duplicate emails
                List<string> ssEmails = new List<string>();
                foreach (JToken row in tableRows)
                {
                    ssEmails.Add(row.GetElementValue(7));
                }
                if (ssEmails.Count != ssEmails.Distinct().Count())
                {
                    ModelState.AddModelError("DuplicateEmails", "It seems that the Google table contains duplicate emails. Please check the table and try again.");
                    await PopulateViewModel(viewModel);
                    return View("ImportAccounts", viewModel);
                }

                //get teh list of current students' emails in the database
                IList<string> databaseStudentEmails = _studentService.GetStudentEmailsByRoleName(ProfilerRoles.Student);
               
                foreach (JToken row in tableRows)
                {
                    string trainerEmail = row.GetElementValue(0);

                    string sheetRowEmail = row.GetElementValue(7);

                    //check if mentioned trainer exists
                    ApplicationUser trainer = await _userManager.FindByEmailAsync(trainerEmail);

                    if (trainer != null)
                    {

                        //check if the email is already present in the system
                        if (!databaseStudentEmails.Contains(sheetRowEmail))
                        {
                        
                            //pick values from the spreadsheet for the new user
                            ApplicationUser user = new ApplicationUser() { UserName = sheetRowEmail, Email = sheetRowEmail };

                            //generate a password
                            string password = PasswordGenerator.Generate(6, 0);

                            var result = await _userManager.CreateAsync(user, password);
                            if (result.Succeeded)
                            {
                                //add to the dictionary (for testing only)
                                generatedPasswords.Add(user.UserName, password);

                                //add to the role Students
                                var currentUser = await _userManager.FindByNameAsync(user.UserName);
                                await _userManager.AddToRoleAsync(currentUser, ProfilerRoles.Student);

                                //add user info
                                //TODO: parse the number
                                UserInfo userInfo = new UserInfo
                                {
                                    UserId = currentUser.Id,
                                    EnName = row.GetElementValue(1),
                                    EnSurname = row.GetElementValue(2),
                                    RuSurname = row.GetElementValue(3),
                                    RuName = row.GetElementValue(4),
                                    DateOfBirth = ParseDateTimeToBLRStandard(row.GetElementValue(6)),
                                    Email = row.GetElementValue(7),
                                    Phone = row.GetElementValue(8)
                                };

                                await _userInfoService.AddUserInfoAsync(userInfo);

                                //bind userInfo to applicationUser
                                currentUser.UserInfo = userInfo;

                                //keep track of the new email
                                usersToNotify.Add(currentUser);
                                userInfosToNotify.Add(userInfo);

                                try
                                {
                                    //save changes to the database
                                    await _db.SaveChangesAsync();
                                }
                                catch
                                {
                                    ModelState.AddModelError("Import failed", $"Server error: can’t create new account for {userInfo.Email}. Please try again later.");
                                    await PopulateViewModel(viewModel);
                                    return View("ImportAccounts", viewModel);
                                }

                                //pick the created userInfo
                                UserInfo userInfoCreated = _userInfoService.GetUserInfo(currentUser.Email);

                                //TODO: verify datetime
                                Student student = new Student
                                {
                                    TrainerId = trainer.Id,
                                    UserInfoId = userInfoCreated.Id,
                                    DateOfGraduation = ParseDateTimeToBLRStandard(row.GetElementValue(9)),
                                    GraduationMark = Convert.ToInt32(row.GetElementValue(11))
                                };

                                try
                                {
                                    //save the changes
                                    await _studentService.AddOrUpdateStudentAsync(student);
                                    await _db.SaveChangesAsync();
                                }
                                catch
                                {
                                    ModelState.AddModelError("Import failed", $"Server error: can’t create new student for {userInfoCreated.Email}. Please try again later.");
                                    await PopulateViewModel(viewModel);
                                    return View("ImportAccounts", viewModel);
                                }

                                //pick the stream
                                Model.Models.Stream stream = _streamService.GetStreamByShortName(row.Children<JToken>().ElementAt(10).Value<string>());

                                if (stream != null)
                                {
                                    
                                    try
                                    {
                                        //bind stream to the student and save the changes
                                        await _studentService.AddStream(student, stream);
                                        await _db.SaveChangesAsync();
                                    }
                                    catch
                                    {
                                        ModelState.AddModelError("Import failed", $"Server error: can’t create new student for {userInfoCreated.Email}. Please try again later.");
                                        await PopulateViewModel(viewModel);
                                        return View("ImportAccounts", viewModel);
                                    }
                                }
                                //if the spreadsheet has an abbreviation not present in the database
                                else
                                {
                                    ModelState.AddModelError("Import failed", $"Server error: can’t create new student for {userInfoCreated.Email}. Please check the field \"Stream\" in the google table.");
                                    await PopulateViewModel(viewModel);
                                    return View("ImportAccounts", viewModel);
                                }

                                
                            }
                        }
                        //if the email already exists
                        else
                        {

                            //check the stream
                            UserInfo userInfo = _db.UserInfo.FirstOrDefault(ui => ui.Email == sheetRowEmail);
                            Student existingStudent =  _studentService.GetCurrentStudentByUserInfo(_userInfoService.GetUserInfo(sheetRowEmail).Id);
                            Model.Models.Stream stream = _streamService.GetStreamByStudentId(existingStudent.Id);

                            string spreadsheetRowStream = row.GetElementValue(10);

                            //if the stream is different, create new student
                            if (stream.StreamShortName != spreadsheetRowStream)
                            {
                                //TODO: verify datetime
                                Student student = new Student
                                {
                                    TrainerId = trainer.Id,
                                    UserInfoId = userInfo.Id,
                                    DateOfGraduation = ParseDateTimeToBLRStandard(row.GetElementValue(9)),
                                    GraduationMark = Convert.ToInt32(row.GetElementValue(11))
                                };
                                try
                                {
                                    //save changes
                                    await _studentService.AddOrUpdateStudentAsync(student);
                                    await _db.SaveChangesAsync();
                                }
                                catch
                                {
                                    ModelState.AddModelError("Import failed", $"Server error: can’t create new student for {userInfo.Email}. Please try again later.");
                                    await PopulateViewModel(viewModel);
                                    return View("ImportAccounts", viewModel);
                                }

                                //pick the stream
                                Model.Models.Stream streamToAdd = _streamService.GetStreamByShortName(spreadsheetRowStream);
                                try
                                {
                                    //bind stream to the student
                                    await _studentService.AddStream(student, streamToAdd);
                                    await _db.SaveChangesAsync();
                                }
                                catch
                                {
                                    ModelState.AddModelError("Import failed", $"Server error: can’t create new student for {userInfo.Email}. Please try again later.");
                                    await PopulateViewModel(viewModel);
                                    return View("ImportAccounts", viewModel);
                                }

                            }                            
                        }
                    }                    
                }
            }

            ////send emails
            //foreach (ApplicationUser userToNotify in usersToNotify)
            //{
            //    UserInfo thisUserInfo = userInfosToNotify.FirstOrDefault(x => x.UserId == userToNotify.Id);
            //    string userPassword = generatedPasswords.FirstOrDefault(x => x.Key == userToNotify.Email).Value;
            //    string appLink = _configuration.GetSection("ProfileAppLink").Value;

            //    EmailSender emailSender = new EmailSender();
            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine("Здравствуйте, " + thisUserInfo.RuName + " " + thisUserInfo.RuSurname + ".");
            //    sb.AppendLine("");
            //    sb.AppendLine("Для вас была создана учетная запись в системе PROFILE.");
            //    //sb.AppendLine("Please use this link: " + appLink + " and this password: " + userPassword + " to log in to your account.");
            //    sb.AppendLine("Для входа в систему используйте ваш пароль - " + userPassword);
            //    await emailSender.SendEmailAsync(userToNotify.Email, "Данные вашей учетной записи в Системе PROFILE Образовательного центра ПВТ", sb.ToString());
            //}
            
            return View("ImportAccountsResult", generatedPasswords);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudentAccount(string emailToRemove)
        {
            ImportAccountsViewModel viewModel = new ImportAccountsViewModel();

            //fetch the user
            ApplicationUser user = await _userManager.FindByNameAsync(emailToRemove);

            if( user != null)
            {
                try
                {
                    //remove User
                    IdentityResult userResult = await _userManager.DeleteAsync(user);
                    
                    if (userResult.Succeeded)
                    {
                        return View("DeleteResult", emailToRemove);
                    }
                    else
                    {
                        throw new Exception();
                    }
                    
                }
                catch
                {
                    ModelState.AddModelError("Delete failed", "Server error: database was not updated. Please contact the developer.");
                    await PopulateViewModel(viewModel);
                    return View("ImportAccounts", viewModel);
                }

            }

            ModelState.AddModelError("Trainer does not exist", "There is no entry in the database with these parameters. Please contact the developer.");
            await PopulateViewModel(viewModel);
            return View("ImportAccounts", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTrainerAccount(string emailToRemove)
        {
            ImportAccountsViewModel viewModel = new ImportAccountsViewModel();

            //fetch the trainer
            ApplicationUser trainer = await _userManager.FindByNameAsync(emailToRemove);        

            //if trainer exists
            if (trainer != null)
            {
                //find students that have this trainer
                IQueryable<Student> students = _studentService.GetStudentsByTrainerId(trainer.Id);

                //do not delete if the trainer has students
                if (students.Count() > 0)
                {
                    ModelState.AddModelError("Foreign key exception","The trainer has at least one student. Please delete the student before removing the trainer.");
                    await PopulateViewModel(viewModel);
                    return View("ImportAccounts", viewModel);
                }

                //remove user 
                IdentityResult result = await _userManager.DeleteAsync(trainer);

                if (result.Succeeded)
                {
                    return View("DeleteResult", emailToRemove);
                }
                else
                {
                    ModelState.AddModelError("Delete failed", "Server error: database was not updated. Please contact the developer.");
                    await PopulateViewModel(viewModel);
                    return View("ImportAccounts", viewModel);
                }

            }

            //if trainer does not exist
            ModelState.AddModelError("Trainer does not exist", "There is no entry in the database with these parameters. Please contact the developer.");
            await PopulateViewModel(viewModel);
            return View("ImportAccounts", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteApiKey()
        {
            //get the logged user (admin)
            ApplicationUser loggedUser = await GetUserAsync();

            //remove the api key value
            UserInfo userInfo = _userInfoService.GetUserInfo(loggedUser?.Email);
            userInfo.GoogleApiKey = null;

            //save changes
            await _userInfoService.SaveUserInfoAsync(userInfo);

            return RedirectToAction("ImportAccounts");
        }

        #region service methods for UI testing

        //TODO: write a service method that creates and deletes students for tests
        //they can be bound to the default trainer
        //each student has to have their resume set to a specific step
        [HttpGet]
        public async Task<IActionResult> CreateTestAccounts()
        {          

            //Define the web request params
            string apiUrl = "https://sheets.googleapis.com/v4/spreadsheets/";
            string spreadsheetId = "1BK50eogFUI8z1Vmy6gzXRsjTbcywNo8YRgpRKya3qWo";
            string sheetRange = "A2:Z";
            string apiKey = "AIzaSyD6MYQCVZdN93XIL--ekM0SPOyQeY6fkPU";
            string requestUrl = apiUrl + spreadsheetId + "/values/" + sheetRange + "?key=" + apiKey;

            //create request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                //read the response stream
                StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                var jsonString = reader.ReadToEnd();

                //parse the response stream
                JObject deserealizedJson = JsonConvert.DeserializeObject(jsonString) as JObject;
                IEnumerable<JToken> tableRows = deserealizedJson.GetSheetRow(2);

                //verify that the trainer does not exist
                string trainerEmail = tableRows.FirstOrDefault().GetElementValue(0);
                ApplicationUser trainer = await _userManager.FindByEmailAsync(trainerEmail);

                if (trainer == null)
                {

                    //create default trainer
                    trainer = new ApplicationUser() { UserName = trainerEmail, Email = trainerEmail };
                    IdentityResult trainerCreationResult = await _userManager.CreateAsync(trainer, PasswordGenerator.Generate(6, 0));
                    if (trainerCreationResult.Succeeded)
                    {

                        foreach (JToken row in tableRows)
                        {
                            string sheetRowEmail = row.GetElementValue(7);

                            //check if the email is already present in the system
                            ApplicationUser dbUser = await _userManager.FindByEmailAsync(sheetRowEmail);
                            if ( dbUser == null)
                            {

                                //pick values from the spreadsheet for the new user
                                ApplicationUser user = new ApplicationUser() { UserName = sheetRowEmail, Email = sheetRowEmail };

                                var result = await _userManager.CreateAsync(user, row.GetElementValue(12));
                                if (result.Succeeded)
                                {

                                    //add to the role Students
                                    var currentUser = await _userManager.FindByNameAsync(user.UserName);
                                    await _userManager.AddToRoleAsync(currentUser, ProfilerRoles.Student);

                                    //add user info
                                    //TODO: parse the number
                                    UserInfo userInfo = new UserInfo
                                    {
                                        UserId = currentUser.Id,
                                        EnName = row.GetElementValue(1),
                                        EnSurname = row.GetElementValue(2),
                                        RuSurname = row.GetElementValue(3),
                                        RuName = row.GetElementValue(4),
                                        DateOfBirth = ParseDateTimeToBLRStandard(row.GetElementValue(6)),
                                        Email = row.GetElementValue(7),
                                        Phone = row.GetElementValue(8)
                                    };

                                    await _userInfoService.AddUserInfoAsync(userInfo);

                                    //bind userInfo to applicationUser
                                    currentUser.UserInfo = userInfo;

                                    //save changes to the database to assign id to userinfo
                                    await _db.SaveChangesAsync();

                                    //pick the created userInfo
                                    UserInfo userInfoCreated = _userInfoService.GetUserInfo(currentUser.Email);

                                    //TODO: verify datetime
                                    Student student = new Student
                                    {
                                        TrainerId = trainer.Id,
                                        UserInfoId = userInfoCreated.Id,
                                        DateOfGraduation = ParseDateTimeToBLRStandard(row.GetElementValue(9)),
                                        GraduationMark = Convert.ToInt32(row.GetElementValue(11))
                                    };
                                    
                                    await _studentService.AddOrUpdateStudentAsync(student);

                                    //save changes to assign id to the student
                                    await _db.SaveChangesAsync();

                                    //pick the stream
                                    Model.Models.Stream stream = _streamService.GetStreamByShortName(row.GetElementValue(10));

                                    if (stream != null)
                                    {
                                            //bind stream to the student
                                            await _studentService.AddStream(student, stream);                                      
                                    }

                                    //create resume
                                    _resumeService.CreateResumeForStudent(student.Id);
                                    await _db.SaveChangesAsync();

                                    //change resume
                                    Resume resume = _resumeService.GetResumeByStudentId(student.Id);
                                    resume.CurrentStep = Convert.ToInt32(row.GetElementValue(13));
                                    _resumeService.UpdateResume(resume);

                                    //save changes
                                    await _db.SaveChangesAsync();
                                }
                            }
                        }
                    }
                }
                else
                {
                    ErrorViewModel evm = new ErrorViewModel
                    {
                        RequestId = "Something went wrong"
                    };
                    return View("Error", evm);
                }
            }

            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public async Task DeleteTestAccount()
        {
            //Define the web request params
            string apiUrl = "https://sheets.googleapis.com/v4/spreadsheets/";
            string spreadsheetId = "1BK50eogFUI8z1Vmy6gzXRsjTbcywNo8YRgpRKya3qWo";
            string sheetRange = "A2:Z";
            string apiKey = "AIzaSyD6MYQCVZdN93XIL--ekM0SPOyQeY6fkPU";
            string requestUrl = apiUrl + spreadsheetId + "/values/" + sheetRange + "?key=" + apiKey;

            //create request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                //read the response stream
                StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                var jsonString = reader.ReadToEnd();

                //parse the response stream
                JObject deserealizedJson = JsonConvert.DeserializeObject(jsonString) as JObject;
                IEnumerable<JToken> tableRows = deserealizedJson.GetSheetRow(2);

                //delete entries
                foreach (JToken row in tableRows)
                {
                    string sheetRowEmail = row.GetElementValue(7);

                    ApplicationUser userToRemove = await _userManager.FindByEmailAsync(sheetRowEmail);

                    if (userToRemove != null)
                    {
                        await _userManager.DeleteAsync(userToRemove);
                    }
                }

                //delete trainer
                string trainerEmail = tableRows.FirstOrDefault().GetElementValue(0);
                ApplicationUser trainer = await _userManager.FindByEmailAsync(trainerEmail);
                if (trainer != null)
                {
                    await _userManager.DeleteAsync(trainer);
                }

            }
        }

        #endregion

        #region helpers
        public Task<ApplicationUser> GetUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public Task PopulateViewModel(ImportAccountsViewModel viewModel)
        {
            //select students from db Users
            viewModel.studentEmails = _studentService.GetStudentEmailsByRoleName(ProfilerRoles.Student);

            //select trainers from db Users
            viewModel.trainerEmails = _trainerService.GetTrainerEmailsByRoleName(ProfilerRoles.Trainer);

            return Task.CompletedTask;
        }


        //this method helps to standartize the date format (EU/NA)
        public DateTime ParseDateTimeToBLRStandard(string date)
        {
            string[] stringArray = date.Split(new[] { '.' });
            return new DateTime(
                 Convert.ToInt32(stringArray[2]),
                 Convert.ToInt32(stringArray[1]),
                 Convert.ToInt32(stringArray[0])
            );
        }
        #endregion
    }
}