using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class PortfolioResumeService : IPortfolioResumeService
    {
        private readonly ProfileDbContext _dbContext;

        public IResumeService _resumeService => new ResumeService(_dbContext);

        public IPortfolioService _portfolioService => new PortfolioService(_dbContext);

        public PortfolioResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SavePortfoliosAndUpdateResumeAsync(Resume resume, Portfolio[] portfolios)
        {
            _resumeService.UpdateResume(resume);
            await _portfolioService.SavePortfolioAsync(resume.Id, portfolios);
        }
    }
}
