using Profile.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IStudentService
    {
        bool IsExistStudent(int userInfoId);

        Student GetCurrentStudentByUserInfo(int userInfoId);

        Student GetStudentByResumeId (int resumeId);

        IList<string> GetStudentEmailsByRoleName(string roleName);

        Task AddOrUpdateStudentAsync(Student student);

        Task AddStream(Student student, Stream stream);

        IQueryable<Student> GetStudentsByTrainerId(string Id);

        IList<Student> GetAllStudents();

        UserInfo GetStudentInfoByEmail(string userName);

        UserInfo GetUserInfo(Student student);
    }
}
