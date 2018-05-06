using Profile.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface ICertificateService
    {
        IEnumerable<Certificate> GetAllCertificatesForResume(int resumeId);

        Task SaveCertificatesAsync(int resumeId, Certificate[] certificates);
    }
}
