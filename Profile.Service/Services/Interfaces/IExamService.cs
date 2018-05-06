using Profile.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IExamService
    {
        IEnumerable<Exam> GetAllExamsForResume(int resumeId);

        Task SaveExamsAsync(int resumeId, Exam[] exams);
    }
}
