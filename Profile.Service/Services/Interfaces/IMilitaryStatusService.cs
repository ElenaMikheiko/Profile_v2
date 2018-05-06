using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IMilitaryStatusService
    {
        MilitaryStatus GetMilitaryStatusForResume(int resumeId);

        Task SaveMilitaryStatusAsync(int resumeId, string militaryStatus);
    }
}
