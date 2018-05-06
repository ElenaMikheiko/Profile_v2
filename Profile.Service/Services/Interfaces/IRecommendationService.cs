using Profile.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IRecommendationService
    {
        IEnumerable<Recommendation> GetAllRecommendationsForResume(int resumeId);

        Task SaveRecommendationAsync(int resumeId, Recommendation[] recommendations);
    }
}
