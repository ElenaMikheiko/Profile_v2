using Profile.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface ISkillService
    {
        IEnumerable<string> GetAllSkillsForStudent(int studentId);

        IEnumerable<Skill> GetAllSkills();

        Task SaveSkillsAsync(int currentStudentId, string [] skills);

        IEnumerable<string> GetDefaultSkillsByStream(int streamId);

    }
}
