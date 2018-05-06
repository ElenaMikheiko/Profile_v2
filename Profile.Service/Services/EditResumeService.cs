using Microsoft.AspNetCore.Identity;
using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class EditResumeService : IEditResumeService
    {
        private readonly ProfileDbContext _dbContext;

        private readonly UserManager<ApplicationUser> _userManager;

        public IUserInfoService _userInfoService => new UserInfoService(_dbContext);

        public IStudentService _studentService => new StudentService(_dbContext, _userManager);

        public IStreamService _streamService => new StreamService(_dbContext);

        public ISummaryService _summaryService => new SummaryService(_dbContext);

        public ISkillService _skillService => new SkillService(_dbContext);

        public IForeignLanguageService _languageService => new ForeignLanguageService(_dbContext);

        public IEducationService _educationService => new EducationService(_dbContext);

        public ICourseService _courseService => new CourseService(_dbContext);

        public ICertificateService _certificateService => new CertificateService(_dbContext);

        public IExamService _examService => new ExamService(_dbContext);

        public IWorkExperienceService _workExperienceService => new WorkExperienceService(_dbContext);

        public IPortfolioService _portfolioService => new PortfolioService(_dbContext);

        public IMilitaryStatusService _militaryStatusService => new MilitaryStatusService(_dbContext);

        public IRecommendationService _recommendationService => new RecommendationService(_dbContext);

        public IAdditionalInfoService _additionalInfoService => new AdditionalInfoService(_dbContext);

        public EditResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveFullResumeAsync(FilledResume filledResume)
        {
            int userInfoId = _userInfoService.GetUserInfo(filledResume.UserInfo.Email).Id;
            int studentId = _studentService.GetCurrentStudentByUserInfo(userInfoId).Id;

            await _userInfoService.SaveUserInfoAsync(filledResume.UserInfo);
            await _streamService.SaveStreamAsync(studentId, filledResume.StreamId);
            await _summaryService.SaveSummaryAsync(filledResume.ResumeId, filledResume.Summary);
            await _skillService.SaveSkillsAsync(studentId, filledResume.Skills);
            await _languageService.SaveForeignLanguagesAsync(filledResume.ResumeId, filledResume.ForeignLanguages);
            await _educationService.SaveEducationAsync(filledResume.ResumeId, filledResume.Educations);
            await _courseService.SaveCoursesAsync(filledResume.ResumeId, filledResume.Courses);
            await _certificateService.SaveCertificatesAsync(filledResume.ResumeId, filledResume.Certificates);
            await _examService.SaveExamsAsync(filledResume.ResumeId, filledResume.Exams);
            await _workExperienceService.SaveWorkExperienceAsync(filledResume.ResumeId, filledResume.WorkExperiences);
            await _portfolioService.SavePortfolioAsync(filledResume.ResumeId, filledResume.Portfolios);
            await _militaryStatusService.SaveMilitaryStatusAsync(filledResume.ResumeId, filledResume.MilitaryStatus.Status);
            await _additionalInfoService.SaveAdditionalInfoAsync(filledResume.ResumeId, filledResume.AdditionalInfo);
            await _recommendationService.SaveRecommendationAsync(filledResume.ResumeId, filledResume.Recommendations);
        }
    }
}
