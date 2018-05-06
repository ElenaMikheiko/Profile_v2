using Profile.DataAccess.Data;
using Profile.Model.Models;
using System.Linq;

namespace Profile.Web.Initializers
{
    public static class EducationLevelInitializer
    {
        public static void Initialize(ProfileDbContext context)
        {
            if (!context.EducationLevels.Any())
            {
                context.EducationLevels.AddRange(
                    new EducationLevel
                    {
                        Level = "Higher"
                    },
                    new EducationLevel
                    {
                        Level = "Bachelor"
                    },
                    new EducationLevel
                    {
                        Level = "Master"
                    },
                    new EducationLevel
                    {
                        Level = "Candidate of science"
                    },
                    new EducationLevel
                    {
                        Level = "Doctor of science"
                    },
                    new EducationLevel
                    {
                        Level = "Incomplete higher"
                    },
                    new EducationLevel
                    {
                        Level = "Vocational secondary",
                    },
                    new EducationLevel
                    {
                        Level = "Secondary",
                    },
                    new EducationLevel
                    {
                        Level = "another",
                    }
                );

                context.SaveChanges();
            }
        }
    }
}