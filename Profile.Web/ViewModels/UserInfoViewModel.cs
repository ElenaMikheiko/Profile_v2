using Microsoft.AspNetCore.Http;
using Profile.Model.Models;

namespace Profile.Web.ViewModels
{
    public class UserInfoViewModel
    {
        public UserInfo StartUserInfo { get; set; }

        public IFormFile fileInput { get; set; }

        public Stream Stream { get; set; }

        public bool IsResumeExists { get; set; }
    }
}
