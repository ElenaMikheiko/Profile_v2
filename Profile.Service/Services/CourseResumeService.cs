using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class CourseResumeService : ICourseResumeService
    {
        private readonly ProfileDbContext _dbContext;

        public IResumeService _resumeService => new ResumeService(_dbContext);

        public ICourseService _courseService => new CourseService(_dbContext);

        public CourseResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveCoursesAndUpdateResumeAsync(Resume resume, Course[] courses)
        {
            _resumeService.UpdateResume(resume);

            await _courseService.SaveCoursesAsync(resume.Id, courses);
        }
    }
}
