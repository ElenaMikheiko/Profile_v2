using Profile.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IPortfolioService
    {
        IEnumerable<Portfolio> GetPortfolioForResume(int resumeId);

        Task SavePortfolioAsync(int resumeId, Portfolio[] portfolioMass);
    }
}
