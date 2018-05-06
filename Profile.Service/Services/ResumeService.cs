using System.Linq;
using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Model.Models.Infrastructure;
using Profile.Service.Services.Interfaces;

namespace Profile.Service.Services
{
    public class ResumeService : IResumeService
    {
        private ProfileDbContext _db;

        public ResumeService(ProfileDbContext db)
        {
            _db = db;
        }

        public void CreateResumeForStudent(int studentId)
        {
            Resume resume = new Resume
            {
                StudentId = studentId,
                Status = ResumeStatuses.New
            };
            _db.Resume.Add(resume);

            //we have to call SaveChange explicitly because we need to retrieve id further in ResumeController
            _db.SaveChanges();
        }

        public Resume GetResumeById(int resumeId)
        {
            return _db.Resume.FirstOrDefault(m => m.Id == resumeId);
        }

        public Resume GetResumeByStudentId(int studentId)
        {
            return _db.Resume.FirstOrDefault(m => m.StudentId == studentId);
        }

        public void UpdateResume(Resume resume)
        {
            _db.Resume.Update(resume);
        }
    }
}
