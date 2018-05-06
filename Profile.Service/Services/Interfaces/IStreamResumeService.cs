using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IStreamResumeService
    {
        Task SaveStreamAndUpdateResumeAsync(Resume resume, int currentStudentId, int objectiveId);
    }
}