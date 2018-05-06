using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class CertificateExamResumeService : ICertificateExamResumeService
    {
        private readonly ProfileDbContext _dbContext;

        public ICertificateExamService _certificateExamService => new CertificateExamService(_dbContext);

        public IResumeService _resumeService => new ResumeService(_dbContext);

        public CertificateExamResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveCertificatesExamsAndUpdateResumeAsync(Resume resume, Certificate[] certificates, Exam[] exams)
        {
            _resumeService.UpdateResume(resume);

            await _certificateExamService.SaveCertificatesExamsAsync(resume.Id, certificates, exams);
        }
    }
}