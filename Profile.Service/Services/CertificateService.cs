using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class CertificateService : ICertificateService
    {
        private ProfileDbContext _db;

        public CertificateService(ProfileDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Certificate> GetAllCertificatesForResume(int resumeId)
        {
            return _db.Certificates.Where(c => c.ResumeId == resumeId).ToArray();
        }

        public async Task SaveCertificatesAsync(int resumeId, Certificate[] certificates)
        {
            if (certificates.Length != 0)
            {
                //if there are certificates for current CV, to delete them
                var existingCertificates = _db.Certificates.Where(c => c.ResumeId == resumeId).ToList();
                if (existingCertificates.Count() != 0)
                {
                    foreach (var certificate in existingCertificates)
                    {
                        _db.Certificates.Remove(certificate);
                    }
                }

                //Create new records about certificates for current CV
                foreach (var certificate in certificates)
                {
                    certificate.ResumeId = resumeId;
                    _db.Certificates.Add(certificate);
                }
            }
        }
    }
}
