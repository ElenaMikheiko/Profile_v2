using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class RecommendationService : IRecommendationService
    {
        public ProfileDbContext _db;

        public RecommendationService(ProfileDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Recommendation> GetAllRecommendationsForResume(int resumeId)
        {
            return _db.Recommendations.Where(r => r.ResumeId == resumeId).ToList();
        }

        public async Task SaveRecommendationAsync(int resumeId, Recommendation[] recommendations)
        {
            if (recommendations.Length != 0)
            {
                //if there are recommends for current CV, to delete them
                var existingRecommendations = _db.Recommendations.Where(c => c.ResumeId == resumeId).ToList();
                if (existingRecommendations.Count()!=0)
                {
                    foreach (var recommendation in existingRecommendations)
                    {
                        _db.Recommendations.Remove(recommendation);
                    }
                }

                foreach (var recommendation in recommendations)
                {
                    recommendation.ResumeId = resumeId;
                    _db.Recommendations.Add(recommendation);
                }
            }
        }
    }
}