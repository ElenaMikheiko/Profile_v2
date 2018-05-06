using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IWorkExperienceResumeService
    {
        Task SaveWorkExperiencesAndUpdateResumeAsync(Resume resume, WorkExperience[] workExperiences);
    }
}
