using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class MilitaryStatusResumeService : IMilitaryStatusResumeService
    {
        private readonly ProfileDbContext _dbContext;

        public IResumeService _resumeService => new ResumeService(_dbContext);

        public IMilitaryStatusService _militaryStatusService => new MilitaryStatusService(_dbContext);

        public MilitaryStatusResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveMilitaryStatusAndUpdateResumeAsync(Resume resume, string militaryStatus)
        {
            _resumeService.UpdateResume(resume);
            await _militaryStatusService.SaveMilitaryStatusAsync(resume.Id, militaryStatus);
        }
    }
}
