using Microsoft.EntityFrameworkCore;
using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class UserInfoService : IUserInfoService
    {
        private ProfileDbContext _db;

        public UserInfoService(ProfileDbContext db)
        {
            _db = db;
        }

        public async Task AddUserInfoAsync(UserInfo userInfo)
        {
            userInfo.Phone = TrimPhoneNumber(userInfo.Phone);

            await _db.UserInfo.AddAsync(userInfo);
        }

        public UserInfo GetUserInfo(string userName)
        {
            return _db.UserInfo.Include(u => u.User).FirstOrDefault(u => u.Email == userName);
        }

        public UserInfo GetUserInfoByUserId(string userId)
        {
            return _db.UserInfo.FirstOrDefault(ui => ui.UserId == userId);
        }

        public void SavePhoto(string userName, string fileInput)
        {
            var user = GetUserInfo(userName);

            string base64 = fileInput.Split(',')[1].Trim();
            var bytes = Convert.FromBase64String(base64);

            user.Photo = bytes;
            _db.UserInfo.Update(user);
        }

        public async Task SaveUserInfoAsync(UserInfo userInfo)
        {
            var user = GetUserInfo(userInfo.Email);
            user.EnName = userInfo.EnName;
            user.EnSurname = userInfo.EnSurname;
            user.Phone = TrimPhoneNumber(userInfo.Phone);
            user.Skype = userInfo.Skype;
            user.Linkedin = userInfo.Linkedin;

            _db.UserInfo.Update(user);
        }

        /// <summary>
        /// If the number starts with '375' - trims the last digits.
        /// <para></para>
        /// If the number has only 9 digits - append '375' at the start.
        /// </summary>
        private string TrimPhoneNumber(string phoneNumber)
        {
            StringBuilder sb = new StringBuilder();
            string[] arr = phoneNumber.Split(new[] { '+', '(', ')', ' ', '-' });
            foreach(string str in arr)
            {
                sb.Append(str);
            }

            string trimmedPhoneNumber = sb.ToString();

            if (trimmedPhoneNumber.StartsWith("375"))
            {
                if (trimmedPhoneNumber.Length > 12)
                {
                    trimmedPhoneNumber = trimmedPhoneNumber.Substring(0, 12);
                }
            }
            else if (trimmedPhoneNumber.Length == 9)
            {
                trimmedPhoneNumber = "375" + trimmedPhoneNumber;
            }
            else
            {
                throw new Exception("The number is not in a correct format.");
            }


            return trimmedPhoneNumber;
        }
    }
}
