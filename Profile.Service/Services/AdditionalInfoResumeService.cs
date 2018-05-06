using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class AdditionalInfoResumeService : IAdditionalInfoResumeService
    {
        private readonly ProfileDbContext _dbContext;

        public IResumeService _resumeService => new ResumeService(_dbContext);

        public IAdditionalInfoService _additionalInfoService => new AdditionalInfoService(_dbContext);

        public AdditionalInfoResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAdditionalInfoAndUpdateResumeAsync(Resume resume, AdditionalInfo info)
        {
            _resumeService.UpdateResume(resume);
            await _additionalInfoService.SaveAdditionalInfoAsync(resume.Id, info);
        }
    }
}
