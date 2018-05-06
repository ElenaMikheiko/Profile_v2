using Profile.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IEducationService
    {
        IEnumerable<Education> GetAllEducationsForResume(int resumeId);

        IEnumerable<EducationLevel> GetEducationLevels();

        Task SaveEducationAsync(int resumeId, Education [] educations);
    }
}
