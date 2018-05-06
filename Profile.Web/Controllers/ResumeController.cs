using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Profile.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Profile.Web.ViewModels;
using Profile.Model.Infrastructure;
using Profile.Service.Services.Interfaces;
using Profile.Model.Models.Infrastructure;

namespace Profile.Web.Controllers
{
    [Authorize(Roles = ProfilerRoles.Student)]
    public class ResumeController : Controller
    {
        private readonly IUserInfoResumeService _userInfoResumeService;

        private readonly IStreamResumeService _streamResumeService;

        private readonly ISummaryResumeService _summaryResumeService;

        private readonly ISkillResumeService _skillResumeService;

        private readonly IForeingLanguageResumeService _foreingLanguageResumeService;

        private readonly IEducationResumeService _educationResumeService;

        private readonly ICourseResumeService _courseResumeService;

        private readonly ICertificateExamResumeService _certificateExamResumeService;

        private readonly IWorkExperienceResumeService _workExperienceResumeService;

        private readonly IPortfolioResumeService _portfolioResumeService;

        private readonly IMilitaryStatusResumeService _militaryStatusResumeService;

        private readonly IAdditionalInfoResumeService _additionalInfoResumeService;

        private readonly IRecommendationResumeService _recommendationResumeService;

        private readonly IUserInfoService _userInfoService;

        private readonly IStudentService _studentService;

        private readonly IResumeService _resumeService;

        private readonly IStreamService _streamService;

        private readonly ISummaryService _summaryService;

        private readonly ISkillService _skillService;

        private readonly IForeignLanguageService _languageService;

        private readonly IEducationService _educationService;

        private readonly ICourseService _courseService;

        private readonly ICertificateService _certificateService;

        private readonly IExamService _examService;

        private readonly IWorkExperienceService _workExperienceService;

        private readonly IPortfolioService _portfolioService;

        private readonly IMilitaryStatusService _militaryStatusService;

        private readonly IRecommendationService _recommendationService;

        private readonly IAdditionalInfoService _additionalInfoService;

        private readonly IDateService _dateService;

        private UserInfo _userInfo => _userInfoService.GetUserInfo(User.Identity.Name);

        #region constructor

        public ResumeController(IStudentService studentService, IResumeService resumeService, IUserInfoService userInfoService,
                                IStreamService streamService, ISummaryService summaryService,
                                ISkillService skillService, IForeignLanguageService languageService, IEducationService educationService, 
                                ICourseService courseService, ICertificateService certificateService, IExamService examService, 
                                IWorkExperienceService workExperienceService, IPortfolioService portfolioService, IMilitaryStatusService militaryStatusService, 
                                IRecommendationService recommendationService, IAdditionalInfoService additionalInfoService, IDateService dateService,
                                IUserInfoResumeService userInfoResumeService, IStreamResumeService streamResumeService,
                                ISummaryResumeService summaryResumeService, ISkillResumeService skillResumeService,
                                IForeingLanguageResumeService foreingLanguageResumeService, IEducationResumeService educationResumeService,
                                ICourseResumeService courseResumeService, IWorkExperienceResumeService workExperienceResumeService,
                                IPortfolioResumeService portfolioResumeService, IMilitaryStatusResumeService militaryStatusResumeService,
                                IAdditionalInfoResumeService additionalInfoResumeService, IRecommendationResumeService recommendationResumeService,
                                ICertificateExamResumeService certificateExamResumeService)
        {
            _userInfoResumeService = userInfoResumeService;
            _streamResumeService = streamResumeService;
            _summaryResumeService = summaryResumeService;
            _skillResumeService = skillResumeService;
            _foreingLanguageResumeService = foreingLanguageResumeService;
            _educationResumeService = educationResumeService;
            _courseResumeService = courseResumeService;
            _certificateExamResumeService = certificateExamResumeService;
            _workExperienceResumeService = workExperienceResumeService;
            _portfolioResumeService = portfolioResumeService;
            _militaryStatusResumeService = militaryStatusResumeService;
            _additionalInfoResumeService = additionalInfoResumeService;
            _recommendationResumeService = recommendationResumeService;

            _userInfoService = userInfoService;
            _studentService = studentService;
            _resumeService = resumeService;
            _streamService = streamService;
            _summaryService = summaryService;
            _skillService = skillService;
            _languageService = languageService;
            _educationService = educationService;
            _courseService = courseService;
            _certificateService = certificateService;
            _examService = examService;
            _workExperienceService = workExperienceService;
            _portfolioService = portfolioService;
            _militaryStatusService = militaryStatusService;
            _additionalInfoService = additionalInfoService;
            _recommendationService = recommendationService;
            _dateService = dateService;
        }

        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new ResumeViewModel();

            #region Fill data to viewmodel (if it's exist)

            // Get info about current user
            vm.UserInfo = _userInfo;
            var currentStudent = _studentService.GetCurrentStudentByUserInfo(vm.UserInfo.Id);

            //Get current Resume Id
            Resume resume = _resumeService.GetResumeByStudentId(currentStudent.Id);
            
            //create new resume if it doesn't exist
            if (resume == null)
            {
                _resumeService.CreateResumeForStudent(currentStudent.Id);
            }

            //Fill data to viewmodel
            int resumeId = _resumeService.GetResumeByStudentId(currentStudent.Id).Id;
            vm.ResumeId = resumeId;
            vm.CurrentResumeStep = _resumeService.GetResumeByStudentId(currentStudent.Id).CurrentStep;

            var stream = _streamService.GetStreamByStudentId(currentStudent.Id);
            if (stream != null)
            {
                vm.StreamFullName = stream.StreamFullName;
            }

            var summary = _summaryService.GetSummaryByResumeId(resumeId);
            if (summary != null)
            {
                vm.Summary = summary.Text;
            }

            string [] existingStudentsSkill = _skillService.GetAllSkillsForStudent(currentStudent.Id).ToArray();
            if(existingStudentsSkill.Length != 0)
            {
                vm.Skills = _skillService.GetAllSkillsForStudent(currentStudent.Id).ToArray();
            }
            else
            {
                //If Student hasn't skills in DB, get the default skills by stream
                vm.Skills = _skillService.GetDefaultSkillsByStream(stream.Id).ToArray();
            }

            vm.ForeignLanguages = _languageService.GetAllForeignLanguagesForResume(resumeId).ToDictionary(x => x.LanguageId, x => x.LanguageLevelId);
            vm.Educations = _educationService.GetAllEducationsForResume(resumeId).ToArray();
            vm.Courses = _courseService.GetAllCoursesForResume(resumeId).ToArray();
            vm.Certificates = _certificateService.GetAllCertificatesForResume(resumeId).ToArray();
            vm.Exams = _examService.GetAllExamsForResume(resumeId).ToArray();

            WorkExperience[] workExperiences = _workExperienceService.GetWorkExperienceForResume(resumeId).ToArray();
            vm.WorkExperiences = new WorkExperienceViewModel[workExperiences.Length];
            if (workExperiences.Count() != 0)
            {
                for (int i = 0; i < workExperiences.Count(); i++)
                {
                    vm.WorkExperiences[i] = new WorkExperienceViewModel(workExperiences[i]);
                }
            }

            vm.Portfolios = _portfolioService.GetPortfolioForResume(resumeId).ToArray();
            vm.MilitaryStatus = _militaryStatusService.GetMilitaryStatusForResume(resumeId);
            vm.Recommendations = _recommendationService.GetAllRecommendationsForResume(resumeId).ToArray();
            vm.AdditionalInfo = _additionalInfoService.GetAdditionalInfo(resumeId);

            #endregion

            #region Fill data to dropdown lists

            //Get all languages from table Languages
            List<Language> languages = _languageService.GetAllLanguages().ToList();
            languages.Insert(0, languages.First(l => l.Name == "English"));
            var index = languages.FindLastIndex(l => l.Name == "English");
            languages.RemoveAt(index);
            //Fill data to dropdownlist Languages
            vm.Languages = languages;

            //Get all language levels from table LanguageLevels
            List<LanguageLevel> languageLevels = _languageService.GetAllLanguageLevels().ToList();
            languageLevels.Insert(0, new LanguageLevel { LevelName = "---", Id = 0 });
            //Fill data to dropdownlist language levels
            vm.LanguageLevels = languageLevels;

            //Get all skills from table Skills
            vm.SkillList = _skillService.GetAllSkills().ToList();

            //Get all Months, Years from DateService
            vm.Months = _dateService.GetAllMonths();
            vm.Years = _dateService.GetAllYears().ToList();

            //Fill data to dropdownlist Education Levels
            vm.EducationLevels = _educationService.GetEducationLevels().ToList();

            #endregion

            //TODO: add more other statuses, when they will be implemented
            if (resume != null && resume.Status == ResumeStatuses.Submitted)
            {
                return RedirectToAction(nameof(ResumeReviewController.Index), "ResumeReview", new { resumeId = resume.Id });
            }
            else
            {
                return View("Index", vm);
            }
        }

        //Save ContactInfo
        [HttpPost]
        public async Task<IActionResult> SaveUserInfoAsync(ResumeViewModel vm)
        {
            var user = _userInfo;
            vm.UserInfo.Email = user.Email;
            if (ModelState.IsValid)
            {
                Resume resume = _resumeService.GetResumeById(vm.ResumeId);
                resume.CurrentStep = vm.CurrentResumeStep;

                await _userInfoResumeService.SaveUserInfoAndUpdateResumeAsync(resume, vm.UserInfo);
            }

            return RedirectToAction("Index", vm);
        }

        //Save Objective
        [HttpPost]
        public async Task<IActionResult> SaveStreamAsync(ResumeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                UserInfo userInfo = _userInfo;
                Student currentStudent = _studentService.GetCurrentStudentByUserInfo(userInfo.Id);
                Resume resume = _resumeService.GetResumeById(vm.ResumeId);
                resume.CurrentStep = vm.CurrentResumeStep;
                int streamId = _streamService.GetStreamByFullName(vm.StreamFullName).Id;

                await _streamResumeService.SaveStreamAndUpdateResumeAsync(resume, currentStudent.Id, streamId);
            }

            return RedirectToAction("Index", vm);
        }

        //Save Summary
        [HttpPost]
        public async Task<IActionResult> SaveSummaryAsync(ResumeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Resume resume = _resumeService.GetResumeById(vm.ResumeId);
                resume.CurrentStep = vm.CurrentResumeStep;

                await _summaryResumeService.SaveSummaryAndUpdateResumeAsync(resume, vm.Summary);
            }

            return RedirectToAction("Index", vm);
        }

        //Save Skills
        [HttpPost]
        public async Task<IActionResult> SaveSkillsAsync(ResumeViewModel vm)
        {
            var userInfo = _userInfo;
            var currentStudent = _studentService.GetCurrentStudentByUserInfo(userInfo.Id);

            if (ModelState.IsValid)
            {
                Resume resume = _resumeService.GetResumeById(vm.ResumeId);
                resume.CurrentStep = vm.CurrentResumeStep;

                await _skillResumeService.SaveSkillsAndUpdateResumeAsync(resume, currentStudent.Id, vm.Skills);
            }

            return RedirectToAction("Index", vm);
        }

        //Save Language
        [HttpPost]
        public async Task<IActionResult> SaveLanguageAsync(ResumeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Resume resume = _resumeService.GetResumeById(vm.ResumeId);
                resume.CurrentStep = vm.CurrentResumeStep;

                await _foreingLanguageResumeService.SaveForeignLanguagesAndUpdateResumeAsync(resume, vm.ForeignLanguages);
            }

            return RedirectToAction("Index", vm);
        }

        //Save Education
        [HttpPost]
        public async Task<IActionResult> SaveEducationAsync(ResumeViewModel vm)
        {
            if(ModelState.IsValid)
            {
                Resume resume = _resumeService.GetResumeById(vm.ResumeId);
                resume.CurrentStep = vm.CurrentResumeStep;

                await _educationResumeService.SaveEducationsAndUpdateResumeAsync(resume, vm.Educations);
            }

            return RedirectToAction("Index", vm);
        }

        //Save Professional development, courses
        [HttpPost]
        public async Task<IActionResult> SaveCoursesAsync(ResumeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Resume resume = _resumeService.GetResumeById(vm.ResumeId);
                resume.CurrentStep = vm.CurrentResumeStep;

                await _courseResumeService.SaveCoursesAndUpdateResumeAsync(resume, vm.Courses);
            }

            return RedirectToAction("Index", vm);
        }

        //Save Electronic certificate, tests, exams
        [HttpPost]
        public async Task<IActionResult> SaveExamsAsync(ResumeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Resume resume = _resumeService.GetResumeById(vm.ResumeId);
                resume.CurrentStep = vm.CurrentResumeStep;

                await _certificateExamResumeService.SaveCertificatesExamsAndUpdateResumeAsync(resume, vm.Certificates, vm.Exams);
            }

            return RedirectToAction("Index", vm);
        }

        //Save Work experience
        [HttpPost]
        public async Task<IActionResult> SaveWorkExperienceAsync(ResumeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                WorkExperience[] workExperiences = new WorkExperience[vm.WorkExperiences.Length];

                for (int i=0; i<vm.WorkExperiences.Count(); i++)
                {
                    workExperiences[i] = vm.WorkExperiences[i].ToWorkExperience();
                }

                Resume resume = _resumeService.GetResumeById(vm.ResumeId);
                resume.CurrentStep = vm.CurrentResumeStep;

                await _workExperienceResumeService.SaveWorkExperiencesAndUpdateResumeAsync(resume, workExperiences);
            }

            return RedirectToAction("Index", vm);
        }

        //Save Portfolio
        [HttpPost]
        public async Task<IActionResult> SavePortfolioAsync(ResumeViewModel vm)
        {
            if(ModelState.IsValid)
            {
                Resume resume = _resumeService.GetResumeById(vm.ResumeId);
                resume.CurrentStep = vm.CurrentResumeStep;

                await _portfolioResumeService.SavePortfoliosAndUpdateResumeAsync(resume, vm.Portfolios);
            }

            return RedirectToAction("Index", vm);
        }

        //Save MilitaryStatus
        [HttpPost]
        public async Task<IActionResult> SaveMilitaryStatusAsync(ResumeViewModel vm)
        {
            if(ModelState.IsValid)
            {
                Resume resume = _resumeService.GetResumeById(vm.ResumeId);
                resume.CurrentStep = vm.CurrentResumeStep;

                await _militaryStatusResumeService.SaveMilitaryStatusAndUpdateResumeAsync(resume, vm.MilitaryStatus.Status);
            }

            return RedirectToAction("Index", vm);
        }

        //Save AdditionalInfo
        [HttpPost]
        public async Task<IActionResult> SaveAdditionalInfoAsync(ResumeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Resume resume = _resumeService.GetResumeById(vm.ResumeId);
                resume.CurrentStep = vm.CurrentResumeStep;

                await _additionalInfoResumeService.SaveAdditionalInfoAndUpdateResumeAsync(resume, vm.AdditionalInfo);
            }

            return RedirectToAction("Index", vm);
        }

        //Save Recommendation
        [HttpPost]
        public async Task<IActionResult> SaveRecomendationsAsync(ResumeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Resume resume = _resumeService.GetResumeById(vm.ResumeId);
                resume.CurrentStep = vm.CurrentResumeStep;

                await _recommendationResumeService.SaveRecommendationsAndUpdateResumeAsync(resume, vm.Recommendations);
            }

            return RedirectToAction("Index", vm);
        }

    }
}