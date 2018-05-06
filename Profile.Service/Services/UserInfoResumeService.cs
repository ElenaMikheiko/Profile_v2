using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class UserInfoResumeService : IUserInfoResumeService
    {
        private readonly ProfileDbContext _dbContext;

        public IResumeService _resumeService => new ResumeService(_dbContext);

        public IUserInfoService _userInfoService => new UserInfoService(_dbContext);

        public UserInfoResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveUserInfoAndUpdateResumeAsync(Resume resume, UserInfo userInfo)
        {
            _resumeService.UpdateResume(resume);
            await _userInfoService.SaveUserInfoAsync(userInfo);
        }

    }
}
