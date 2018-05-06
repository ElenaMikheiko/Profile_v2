using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface ISkillResumeService
    {
        Task SaveSkillsAndUpdateResumeAsync(Resume resume, int currentStudentId, string[] skills);
    }
}
