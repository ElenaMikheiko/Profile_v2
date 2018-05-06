using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class EducationService : IEducationService
    {
        private ProfileDbContext _db;

        public EducationService(ProfileDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Education> GetAllEducationsForResume(int resumeId)
        {
            return _db.Education.Where(e => e.ResumeId == resumeId).ToList();
        }

        public IEnumerable<EducationLevel> GetEducationLevels()
        {
            return _db.EducationLevels.ToList();
        }

        public async Task SaveEducationAsync(int resumeId, Education[] educations)
        {
            if (educations != null)
            {
                //if there is education for current CV, to delete it
                var existingEducations = _db.Education.Where(e => e.ResumeId == resumeId).ToList();
                if (existingEducations.Count()!=0)
                {
                    foreach (var education in existingEducations)
                    {
                        _db.Education.Remove(education);
                    }
                }
                //Create new records about education for current CV
                foreach (var education in educations)
                {
                    education.ResumeId = resumeId;
                    _db.Education.Add(education);
                }
            }
        }
    }
}