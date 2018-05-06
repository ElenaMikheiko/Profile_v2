using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IAdditionalInfoResumeService
    {
        Task SaveAdditionalInfoAndUpdateResumeAsync(Resume resume, AdditionalInfo info);
    }
}
