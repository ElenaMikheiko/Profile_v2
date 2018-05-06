using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface ICertificateExamResumeService
    {
        Task SaveCertificatesExamsAndUpdateResumeAsync(Resume resume, Certificate[] certificates, Exam[] exams);
    }
}
