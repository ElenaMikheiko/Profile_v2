using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Profile.Model.Infrastructure;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using Profile.Web.ViewModels;

namespace Profile.Web.Controllers
{
    [Authorize(Roles = ProfilerRoles.Student)]
    public class EditResumeController : Controller
    {
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

        private readonly ICertificateExamService _certificateExamService;

        private readonly IEditResumeService _editResumeService;

        private UserInfo _userInfo => _userInfoService.GetUserInfo(User.Identity.Name);

        public EditResumeController(IUserInfoService userInfoService, IStudentService studentService, IResumeService resumeService,
                                IStreamService streamService, ISummaryService summaryService, ICertificateExamService certificateExamService,
                                ISkillService skillService, IForeignLanguageService languageService, IEducationService educationService,
                                ICourseService courseService, ICertificateService certificateService, IExamService examService,
                                IWorkExperienceService workExperienceService, IPortfolioService portfolioService, IMilitaryStatusService militaryStatusService,
                                IRecommendationService recommendationService, IAdditionalInfoService additionalInfoService, IDateService dateService,
                                IEditResumeService editResumeService)
        {
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
            _certificateExamService = certificateExamService;
            _editResumeService = editResumeService;
        }

        [HttpGet]
        public async Task<IActionResult> EditResume(int resumeId)
        {
            var student = _studentService.GetStudentByResumeId(resumeId);

            ResumeViewModel vm = new ResumeViewModel
            {
                ResumeId = resumeId,
                UserInfo = _userInfo,
                StreamFullName = _streamService.GetStreamByStudentId(student.Id).StreamFullName,
                Summary = _summaryService.GetSummaryByResumeId(resumeId).Text,
                Skills = _skillService.GetAllSkillsForStudent(student.Id).ToArray(),
                ForeignLanguages = _languageService.GetAllForeignLanguagesForResume(resumeId).ToDictionary(x => x.LanguageId, x => x.LanguageLevelId),
                Educations = _educationService.GetAllEducationsForResume(resumeId).ToArray(),
                Courses = _courseService.GetAllCoursesForResume(resumeId).ToArray(),
                Certificates = _certificateService.GetAllCertificatesForResume(resumeId).ToArray(),
                Exams = _examService.GetAllExamsForResume(resumeId).ToArray(),
                Portfolios = _portfolioService.GetPortfolioForResume(resumeId).ToArray(),
                MilitaryStatus = _militaryStatusService.GetMilitaryStatusForResume(resumeId),
                AdditionalInfo = _additionalInfoService.GetAdditionalInfo(resumeId),
                Recommendations = _recommendationService.GetAllRecommendationsForResume(resumeId).ToArray()
            };

            WorkExperience[] workExperiences = _workExperienceService.GetWorkExperienceForResume(resumeId).ToArray();
            vm.WorkExperiences = new WorkExperienceViewModel[workExperiences.Length];
            if (workExperiences.Count() != 0)
            {
                for (int i = 0; i < workExperiences.Count(); i++)
                {
                    vm.WorkExperiences[i] = new WorkExperienceViewModel(workExperiences[i]);
                }
            }
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


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditResume(ResumeViewModel viewModel)
        {
            FilledResume filledResume = new FilledResume();

            filledResume.UserInfo = viewModel.UserInfo;
            filledResume.StreamId = _streamService.GetStreamByFullName(viewModel.StreamFullName).Id;
            filledResume.ResumeId = viewModel.ResumeId;
            filledResume.Summary = viewModel.Summary;
            filledResume.Skills = viewModel.Skills;
            filledResume.ForeignLanguages = viewModel.ForeignLanguages;
            filledResume.Educations = viewModel.Educations;
            filledResume.Courses = viewModel.Courses;
            filledResume.Certificates = viewModel.Certificates;
            filledResume.Exams = viewModel.Exams;

            WorkExperience[] workExperiences = new WorkExperience[viewModel.WorkExperiences.Length];

            for (int i = 0; i < viewModel.WorkExperiences.Count(); i++)
            {
                workExperiences[i] = viewModel.WorkExperiences[i].ToWorkExperience();
            }

            filledResume.WorkExperiences = workExperiences;
            filledResume.Portfolios = viewModel.Portfolios;
            filledResume.MilitaryStatus = viewModel.MilitaryStatus;
            filledResume.AdditionalInfo = viewModel.AdditionalInfo;
            filledResume.Recommendations = viewModel.Recommendations;

            await _editResumeService.SaveFullResumeAsync(filledResume);

            return RedirectToAction(nameof(ResumeReviewController.Index), "ResumeReview", new { resumeId = viewModel.ResumeId });
        }
    }
}