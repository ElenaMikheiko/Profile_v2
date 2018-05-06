using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class RecommendationResumeService : IRecommendationResumeService
    {
        private readonly ProfileDbContext _dbContext;

        public IResumeService _resumeService => new ResumeService(_dbContext);

        public IRecommendationService _recommendationService => new RecommendationService(_dbContext);

        public RecommendationResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveRecommendationsAndUpdateResumeAsync(Resume resume, Recommendation[] recommendations)
        {
            _resumeService.UpdateResume(resume);
            await _recommendationService.SaveRecommendationAsync(resume.Id, recommendations);
        }
    }
}
