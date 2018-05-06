using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IRecommendationResumeService
    {
        Task SaveRecommendationsAndUpdateResumeAsync(Resume resume, Recommendation[] recommendations);
    }
}
