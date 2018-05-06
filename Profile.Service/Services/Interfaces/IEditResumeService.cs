using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IEditResumeService
    {
        Task SaveFullResumeAsync(FilledResume filledResume);
    }
}
