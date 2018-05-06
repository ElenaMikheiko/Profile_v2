using Microsoft.AspNetCore.Identity;

namespace Profile.Model.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual UserInfo UserInfo { get; set; }
    }
}
