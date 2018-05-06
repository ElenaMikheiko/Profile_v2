using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Profile.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Profile.Model.Infrastructure;
using Profile.Service.Services.Interfaces;

namespace Profile.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserInfoService _userInfoService;

        private readonly IStudentService _studentService;

        private readonly IResumeService _resumeService;


        private readonly IStreamService _streamService;

        public HomeController(IUserInfoService userInfoService, IStudentService studentService, IResumeService resumeService, 
                              IStreamService streamService)
        {
            _userInfoService = userInfoService;
            _studentService = studentService;
            _resumeService = resumeService;
            _streamService = streamService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserInfoViewModel vm = new UserInfoViewModel();
            var userInfo = _userInfoService.GetUserInfo(User.Identity.Name);
            vm.StartUserInfo = userInfo;
            if (User.IsInRole(ProfilerRoles.Student))
            {
                var currentStudent = _studentService.GetCurrentStudentByUserInfo(userInfo.Id);
                var currentResume = _resumeService.GetResumeByStudentId(currentStudent.Id);

                vm.Stream = _streamService.GetStreamByStudentId(currentStudent.Id);
                vm.IsResumeExists = currentResume != null ? true : false; 

                return View(vm);
            }
            else if (User.IsInRole(ProfilerRoles.HR))
            {
                return RedirectToAction(nameof(HrManagerController.Index), "HrManager");
            }
            else if(User.IsInRole(ProfilerRoles.Trainer))
            {
                return RedirectToAction(nameof(TrainerController.Index), "Trainer");
            }

            return View(vm);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SavePhoto(string fileInput)
        {
            var user = User.Identity.Name;
            _userInfoService.SavePhoto(user, fileInput);

            return RedirectToAction("Index");
        }
    }
}
