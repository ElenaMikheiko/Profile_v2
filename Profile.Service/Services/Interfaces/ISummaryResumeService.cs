using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface ISummaryResumeService
    {
        Task SaveSummaryAndUpdateResumeAsync(Resume resume, string summaryText);
    }
}
