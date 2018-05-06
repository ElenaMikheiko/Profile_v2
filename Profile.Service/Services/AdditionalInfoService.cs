using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class AdditionalInfoService : IAdditionalInfoService
    {
        private ProfileDbContext _db;

        public AdditionalInfoService(ProfileDbContext db)
        {
            _db = db;
        }

        public AdditionalInfo GetAdditionalInfo(int resumeId)
        {
            return _db.AdditionalInfo.FirstOrDefault(s => s.ResumeId == resumeId);
        }

        public async Task SaveAdditionalInfoAsync(int resumeId, AdditionalInfo info)
        {
            //Update, if user has already had data
            var additionalInfo = _db.AdditionalInfo.FirstOrDefault(x => x.ResumeId == resumeId);
            if (additionalInfo != null)
            {
                additionalInfo.Text = info.Text;
                _db.AdditionalInfo.Update(additionalInfo);
            }
            else
            {
                info.ResumeId = resumeId;
                _db.AdditionalInfo.Add(info);
            }
        }
    }
}
