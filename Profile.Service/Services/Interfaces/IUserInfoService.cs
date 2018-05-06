using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IUserInfoService
    {
        UserInfo GetUserInfo(string userName);

        UserInfo GetUserInfoByUserId(string userId);

        void SavePhoto(string userName, string fileInput);

        Task AddUserInfoAsync(UserInfo userInfo);

        Task SaveUserInfoAsync(UserInfo userInfo);
    }
}
