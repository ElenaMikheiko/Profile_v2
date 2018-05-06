using System.Collections.Generic;

namespace Profile.Model.Infrastructure
{
    public class ProfilerRoles
    {
        public const string Student = "Student";
        public const string Admin = "Admin";
        public const string HR = "HR";
        public const string Trainer = "Trainer";
        public const string UserSessionKey = "User";

        public static List<string> GetRoles
        {
            get
            {
                return new List<string> { Admin, HR, Trainer, Student };
            }
        }
    }
}
