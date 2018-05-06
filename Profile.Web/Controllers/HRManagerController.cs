using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Profile.Model.Infrastructure;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using Profile.Web.ViewModels.HrManagerViewModel;

namespace Profile.Web.Controllers
{
    [Authorize(Roles = ProfilerRoles.HR)]
    public class HrManagerController : Controller
    {
        private readonly IHrManagerService _hrManagerService;
        private readonly IStudentService _studentService;
        private readonly IStreamService _streamService;
        private readonly IUserInfoService _userInfoService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HrManagerController(
            IHrManagerService hrManagerService,
            IStudentService studentService,
            IStreamService streamService,
            IUserInfoService userInfoService,
            UserManager<ApplicationUser> userManager
            )
        {
            _hrManagerService = hrManagerService;
            _studentService = studentService;
            _streamService = streamService;
            _userInfoService = userInfoService;
            _userManager = userManager;
        }
        
        [HttpGet]
        public IActionResult Index()
        {

            //get list of students
            IList<Student> students = _studentService.GetAllStudents();

            if (students.Count() == 0)
            {
                return NotFound();
            }

            HrManagerViewModel viewModel = new HrManagerViewModel();
            viewModel.TableData = new List<TableRow>();

            //fill all rows of the model
            foreach(Student st in students)
            {
                //since we need to manually format many columns from UserInfo
                //it is assigned to a separate var
                UserInfo studentInfo = _studentService.GetUserInfo(st);

                TableRow row = new TableRow();

                //take from UserInfo
                row.DateOfBirth = studentInfo.DateOfBirth.ToShortDateString();
                row.PhoneNumber = studentInfo.Phone;
                row.UserInfo = studentInfo;

                //take from Student
                row.DateOfGraduation = st.DateOfGraduation.ToShortDateString();
                row.Student = st;
                
                //take from Stream
                row.Stream = _streamService.GetStreamByStudentId(st.Id);

                //take from User
                row.TrainerEmail = _userManager.FindByIdAsync(st.TrainerId).GetAwaiter().GetResult().Email;
                
                //add to list
                viewModel.TableData.Add(row);
            }


            return View(viewModel);
        }

    }
}