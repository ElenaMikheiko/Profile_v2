using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private ProfileDbContext _db;

        public WorkExperienceService(ProfileDbContext db)
        {
            _db = db;
        }

        public IEnumerable<WorkExperience> GetWorkExperienceForResume(int resumeId)
        {
            return _db.WorkExperience.Where(w => w.ResumeId == resumeId).ToList();
        }

        public async Task SaveWorkExperienceAsync(int resumeId, WorkExperience[] workExperience)
        {
            if (workExperience.Length != 0)
            {
                var existingExperiences = _db.WorkExperience.Where(c => c.ResumeId == resumeId).ToList();
                if (existingExperiences.Count()!= 0)
                {
                    //if there is work experience for current CV, to delete it
                    foreach (var experience in existingExperiences)
                    {
                        _db.WorkExperience.Remove(experience);
                    }
                }

                //Create new records about work experience for current CV
                foreach (var experience in workExperience)
                {
                    experience.ResumeId = resumeId;
                    await _db.WorkExperience.AddAsync(experience);
                }
            }
        }
    }
}