using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface ICertificateExamService
    {
        Task SaveCertificatesExamsAsync(int resumeId, Certificate[] certificates, Exam[] exams);
    }
}
