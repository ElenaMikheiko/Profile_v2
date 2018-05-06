using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Profile.Model.Models;
using Profile.Model.Models.Infrastructure;
using Profile.Service.Services.Interfaces;
using Profile.Web.ViewModels;

namespace Profile.Web.Controllers
{
    public class ResumeReviewController : Controller
    {
        private readonly IUserInfoService _userInfoService;

        private readonly IStudentService _studentService;

        private readonly IResumeService _resumeService;

        private readonly IStreamService _streamService;

        private readonly ISummaryService _summaryService;

        private readonly ISkillService _skillService;

        private readonly IForeignLanguageService _languageService;

        private readonly IEducationService _educationService;

        private readonly IWorkExperienceService _workExperienceService;

        private readonly IPortfolioService _portfolioService;

        private readonly IMilitaryStatusService _militaryStatusService;

        private readonly IRecommendationService _recommendationService;

        private readonly IAdditionalInfoService _additionalInfoService;

        private readonly ICourseService _courseService;

        private readonly ICertificateService _certificateService;

        private readonly IExamService _examService;

        public ResumeReviewController(IUserInfoService userInfoService, IStudentService studentService, IResumeService resumeService,
                                IStreamService streamService, ISummaryService summaryService,
                                ISkillService skillService, IForeignLanguageService languageService, IEducationService educationService,
                                IWorkExperienceService workExperienceService, IPortfolioService portfolioService, IMilitaryStatusService militaryStatusService,
                                IRecommendationService recommendationService, IAdditionalInfoService additionalInfoService,
                                ICourseService courseService, ICertificateService certificateService, IExamService examService)
        {
            _userInfoService = userInfoService;
            _studentService = studentService;
            _resumeService = resumeService;
            _streamService = streamService;
            _summaryService = summaryService;
            _skillService = skillService;
            _languageService = languageService;
            _educationService = educationService;
            _workExperienceService = workExperienceService;
            _portfolioService = portfolioService;
            _militaryStatusService = militaryStatusService;
            _additionalInfoService = additionalInfoService;
            _recommendationService = recommendationService;
            _courseService = courseService;
            _examService = examService;
            _certificateService = certificateService;

        }

        [HttpGet]
        public IActionResult Index(int resumeId)
        {
            var currentStudent = _studentService.GetStudentByResumeId(resumeId);
            //Get all data for Resume from all tables
            ResumeReviewViewModel vm = new ResumeReviewViewModel
            {
                ResumeId = resumeId,
                ResumeStatus = _resumeService.GetResumeById(resumeId).Status,
                UserInfo = _userInfoService.GetUserInfo(User.Identity.Name),
                Stream = _streamService.GetStreamByStudentId(currentStudent.Id),
                Summary = _summaryService.GetSummaryByResumeId(resumeId),
                Skills = _skillService.GetAllSkillsForStudent(currentStudent.Id).ToArray(),
                ForeignLanguages = _languageService.GetAllForeignLanguagesForResume(resumeId).ToArray(),
                Educations = _educationService.GetAllEducationsForResume(resumeId).ToArray(),
                Courses = _courseService.GetAllCoursesForResume(resumeId).ToArray(),
                Certificates = _certificateService.GetAllCertificatesForResume(resumeId).ToArray(),
                Exams = _examService.GetAllExamsForResume(resumeId).ToArray(),
                WorkExperience = _workExperienceService.GetWorkExperienceForResume(resumeId).ToArray(),
                Portfolio = _portfolioService.GetPortfolioForResume(resumeId).ToArray(),
                MilitaryStatus = _militaryStatusService.GetMilitaryStatusForResume(resumeId),
                AdditionalInfo = _additionalInfoService.GetAdditionalInfo(resumeId),
                Recommendations = _recommendationService.GetAllRecommendationsForResume(resumeId).ToArray()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult SubmitResume(int resumeId)
        {
            Resume resume = _resumeService.GetResumeById(resumeId);
            resume.Status = ResumeStatuses.Submitted;
            _resumeService.UpdateResume(resume);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        //TODO: Delete this method later.
        // For recovering resume status "New" instead "Submitted".  
        [HttpPost]
        public IActionResult SetStatusNewForResume(int resumeId)
        {
            Resume resume = _resumeService.GetResumeById(resumeId);
            resume.Status = ResumeStatuses.New;
            _resumeService.UpdateResume(resume);

            return RedirectToAction("Index", "Home");
        }
        //End TODO
    }
}