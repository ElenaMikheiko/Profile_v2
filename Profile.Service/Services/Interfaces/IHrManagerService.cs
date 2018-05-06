using System.Collections.Generic;
using System.Threading.Tasks;
using Profile.Model.Models;

namespace Profile.Service.Services.Interfaces
{
    public interface IHrManagerService
    {
        Task<ICollection<StudentStream>> GetStudentStreamUserInfos();
    }
}
