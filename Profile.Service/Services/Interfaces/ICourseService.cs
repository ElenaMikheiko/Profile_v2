using Profile.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCoursesForResume(int resumeId);

        Task SaveCoursesAsync(int resumeId, Course[] courses);

    }
}
