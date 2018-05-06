using Microsoft.AspNetCore.Identity;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Collections.Generic;

namespace Profile.Service.Services
{
    public class TrainerService : ITrainerService
    {
        private UserManager<ApplicationUser> _userManager;

        public TrainerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IList<string> GetTrainerEmailsByRoleName(string roleName)
        {
            IList<string> emails = new List<string>();
            IList<ApplicationUser> applicationUsers = _userManager.GetUsersInRoleAsync(roleName).GetAwaiter().GetResult();
            foreach (ApplicationUser applicationUser in applicationUsers)
            {
                emails.Add(applicationUser.Email);
            }

            return emails;
        }
    }
}
