using Profile.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IWorkExperienceService
    {
        IEnumerable<WorkExperience> GetWorkExperienceForResume(int resumeId);

        Task SaveWorkExperienceAsync(int resumeId, WorkExperience[] workExperience);
    }
}
