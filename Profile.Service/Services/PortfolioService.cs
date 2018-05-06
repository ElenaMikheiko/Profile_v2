using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class PortfolioService : IPortfolioService
    {
        private ProfileDbContext _db;

        public PortfolioService(ProfileDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Portfolio> GetPortfolioForResume(int resumeId)
        {
            return _db.Portfolio.Where(m => m.ResumeId == resumeId).ToList();
        }

        public async Task SavePortfolioAsync(int resumeId, Portfolio[] portfolioMass)
        {
            if (portfolioMass.Length != 0)
            {
                //if there is portfolio for current CV, to delete it
                var existingPortfolios = _db.Portfolio.Where(c => c.ResumeId == resumeId).ToList();
                if (existingPortfolios.Count()!=0)
                {
                    foreach (var portfolio in existingPortfolios)
                    {
                        _db.Portfolio.Remove(portfolio);
                    }
                }

                //Create new records about portfolio for current CV
                foreach (var portfolio in portfolioMass)
                {
                    portfolio.ResumeId = resumeId;
                    _db.Portfolio.Add(portfolio);
                }
            }
        }
    }
}
