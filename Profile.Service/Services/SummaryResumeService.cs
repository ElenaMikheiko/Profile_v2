using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class SummaryResumeService : ISummaryResumeService
    {
        private readonly ProfileDbContext _dbContext;

        public IResumeService _resumeService => new ResumeService(_dbContext);

        public ISummaryService _summaryService => new SummaryService(_dbContext);

        public SummaryResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveSummaryAndUpdateResumeAsync(Resume resume, string summaryText)
        {
            _resumeService.UpdateResume(resume);
            await _summaryService.SaveSummaryAsync(resume.Id, summaryText);
        }
    }
}
