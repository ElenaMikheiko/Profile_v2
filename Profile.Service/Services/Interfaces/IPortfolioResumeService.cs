using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IPortfolioResumeService
    {
        Task SavePortfoliosAndUpdateResumeAsync(Resume resume, Portfolio[] portfolios);
    }
}
