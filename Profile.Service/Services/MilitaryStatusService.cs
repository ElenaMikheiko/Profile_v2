using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class MilitaryStatusService : IMilitaryStatusService
    {
        private ProfileDbContext _db;

        public MilitaryStatusService(ProfileDbContext db)
        {
            _db = db;
        }

        public MilitaryStatus GetMilitaryStatusForResume(int resumeId)
        {
            var militaryStatus = _db.MilitaryStatus.FirstOrDefault(m => m.ResumeId == resumeId);
            if (militaryStatus == null)
            {
                militaryStatus = new MilitaryStatus
                {
                    Status = "Doesn't apply"
                };
            }

            return militaryStatus;
        }

        public async Task SaveMilitaryStatusAsync(int resumeId, string militaryStatus)
        {
            var existingStatus = _db.MilitaryStatus.FirstOrDefault(s => s.ResumeId == resumeId);
            if (existingStatus!=null)
            {
                existingStatus.Status = militaryStatus;
                _db.MilitaryStatus.Update(existingStatus);
            }
            else
            {
                MilitaryStatus status = new MilitaryStatus
                {
                    ResumeId = resumeId,
                    Status = militaryStatus
                };
                _db.MilitaryStatus.Add(status);
            }
        }
    }
}