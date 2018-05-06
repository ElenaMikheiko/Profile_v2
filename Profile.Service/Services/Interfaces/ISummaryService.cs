using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface ISummaryService
    {
        Summary GetSummaryByResumeId(int resumeId);

        Task SaveSummaryAsync(int resumeId, string summaryText);
    }
}
