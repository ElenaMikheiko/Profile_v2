using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class SkillResumeService : ISkillResumeService
    {
        private readonly ProfileDbContext _dbContext;

        public IResumeService _resumeService => new ResumeService(_dbContext);

        public ISkillService _skillService => new SkillService(_dbContext);

        public SkillResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveSkillsAndUpdateResumeAsync(Resume resume, int currentStudentId, string[] skills)
        {
            _resumeService.UpdateResume(resume);

            await _skillService.SaveSkillsAsync(currentStudentId, skills);
        }
    }
}
