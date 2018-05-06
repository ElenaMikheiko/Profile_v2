using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class CourseService : ICourseService
    {
        private ProfileDbContext _db;

        public CourseService(ProfileDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Course> GetAllCoursesForResume(int resumeId)
        {
            return _db.Courses.Where(c => c.ResumeId == resumeId).ToList();
        }

        public async Task SaveCoursesAsync(int resumeId, Course[] courses)
        {
            if (courses.Length != 0)
            {
                //if there are courses for current CV, to delete them
                var existingCourses = _db.Courses.Where(c => c.ResumeId == resumeId).ToList();
                if (existingCourses.Count()!= 0)
                {
                    foreach (var course in existingCourses)
                    {
                        _db.Courses.Remove(course);
                    }
                }

                //Create new records about courses for current CV
                foreach (var course in courses)
                {
                    course.ResumeId = resumeId;
                    _db.Courses.Add(course);
                }
            }
        }
    }
}