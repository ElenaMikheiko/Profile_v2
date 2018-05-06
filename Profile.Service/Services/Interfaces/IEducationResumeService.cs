using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IEducationResumeService
    {
        Task SaveEducationsAndUpdateResumeAsync(Resume resume, Education[] educations);
    }
}
