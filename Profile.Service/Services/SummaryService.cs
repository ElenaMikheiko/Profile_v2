using Profile.Model.Models;
using Profile.DataAccess.Data;
using System.Linq;
using System.Threading.Tasks;
using Profile.Service.Services.Interfaces;

namespace Profile.Service.Services
{
    public class SummaryService : ISummaryService
    {
        private ProfileDbContext _db;

        public SummaryService(ProfileDbContext db)
        {
            _db = db;
        }

        public Summary GetSummaryByResumeId(int resumeId)
        {
            return _db.Summary.FirstOrDefault(s => s.ResumeId == resumeId);
        }

        public async Task SaveSummaryAsync(int resumeId, string summaryText)
        {
            //Update, if user has Summary
            var summary = _db.Summary.FirstOrDefault(x => x.ResumeId == resumeId);
            if (summary!=null)
            {
                summary.Text = summaryText;
                _db.Summary.Update(summary);
            }
            else
            {
                var Summary = new Summary
                {
                    ResumeId = resumeId,
                    Text = summaryText
                };
                _db.Summary.Add(Summary);
            }
        }
    }
}
