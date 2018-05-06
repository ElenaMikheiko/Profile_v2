using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class WorkExperienceResumeService : IWorkExperienceResumeService
    {
        private readonly ProfileDbContext _dbContext;

        public IResumeService _resumeService => new ResumeService(_dbContext);

        public IWorkExperienceService _workExperinceService => new WorkExperienceService(_dbContext);

        public WorkExperienceResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveWorkExperiencesAndUpdateResumeAsync(Resume resume, WorkExperience[] workExperiences)
        {
            _resumeService.UpdateResume(resume);
            await _workExperinceService.SaveWorkExperienceAsync(resume.Id, workExperiences);
        }
    }
}
