using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class CertificateExamService : ICertificateExamService
    {
        private readonly ProfileDbContext _dbContext;

        public ICertificateService _certificateService => new CertificateService(_dbContext);

        public IExamService _examService => new ExamService(_dbContext);

        public CertificateExamService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveCertificatesExamsAsync(int resumeId, Certificate[] certificates, Exam[] exams)
        {
            await _certificateService.SaveCertificatesAsync(resumeId, certificates);
            await _examService.SaveExamsAsync(resumeId, exams);
        }
    }
}
