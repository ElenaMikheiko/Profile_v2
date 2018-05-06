using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class EducationResumeService : IEducationResumeService
    {
        private readonly ProfileDbContext _dbContext;

        public IResumeService _resumeService => new ResumeService(_dbContext);

        public IEducationService _educationService => new EducationService(_dbContext);

        public EducationResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveEducationsAndUpdateResumeAsync(Resume resume, Education[] educations)
        {
            _resumeService.UpdateResume(resume);

            await _educationService.SaveEducationAsync(resume.Id, educations);
        }
    }
}
