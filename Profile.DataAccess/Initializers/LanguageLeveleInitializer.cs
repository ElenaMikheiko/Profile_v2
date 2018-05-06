using Profile.DataAccess.Data;
using Profile.Model.Models;
using System.Linq;

namespace Profile.Web.Initializers
{
    public static class LanguageLeveleInitializer
    {
        public static void Initialize(ProfileDbContext context)
        {
            if (!context.LanguageLevels.Any())
            {
                context.LanguageLevels.AddRange(
                    new LanguageLevel
                    {
                        LevelName = "A1 Elementary"
                    },
                    new LanguageLevel
                    {
                        LevelName = "A2 Pre-Intermediate"
                    },
                    new LanguageLevel
                    {
                        LevelName = "B1 Intermediate"
                    },
                    new LanguageLevel
                    {
                        LevelName = "B2 Upper-Intermediate"
                    },
                    new LanguageLevel
                    {
                        LevelName = "C1 Advanced"
                    },
                    new LanguageLevel
                    {
                        LevelName = "C2 Proficiency"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
