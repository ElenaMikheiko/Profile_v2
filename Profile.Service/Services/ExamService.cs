using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class ExamService : IExamService
    {
        private ProfileDbContext _db;

        public ExamService(ProfileDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Exam> GetAllExamsForResume(int resumeId)
        {
            return _db.Exams.Where(e => e.ResumeId == resumeId).ToList();
        }

        public async Task SaveExamsAsync(int resumeId, Exam[] exams)
        {
            if (exams.Length != 0)
            {
                //if there are exams for current CV, to delete them
                var existingExams = _db.Exams.Where(c => c.ResumeId == resumeId).ToList();
                if (existingExams.Count()!=0)
                {
                    foreach (var exam in existingExams)
                    {
                        _db.Exams.Remove(exam);
                    }
                }

                //Create new records about courses for current CV
                foreach (var exam in exams)
                {
                    exam.ResumeId = resumeId;
                    _db.Exams.Add(exam);
                }
            }
        }
    }
}