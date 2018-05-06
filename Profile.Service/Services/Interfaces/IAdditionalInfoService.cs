using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IAdditionalInfoService
    {
        AdditionalInfo GetAdditionalInfo(int resumeId);

        Task SaveAdditionalInfoAsync(int resumeId, AdditionalInfo info);
    }
}
