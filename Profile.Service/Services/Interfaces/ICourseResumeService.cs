using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface ICourseResumeService
    {
        Task SaveCoursesAndUpdateResumeAsync(Resume resume, Course[] courses);
    }
}
