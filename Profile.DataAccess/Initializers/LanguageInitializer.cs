using Profile.DataAccess.Data;
using Profile.Model.Models;
using System.Linq;

namespace Profile.Web.Initializers
{
    public static class LanguageInitializer
    {
        public static void Initialize(ProfileDbContext context)
        {
            if (!context.Languages.Any())
            {
                context.Languages.AddRange(
                    new Language
                    {
                        Name = "English"
                    },
                    new Language
                    {
                        Name = "Afrikaans"
                    },
                    new Language
                    {
                        Name = "Albanian"
                    },
                    new Language
                    {
                        Name = "Arabic"
                    },
                    new Language
                    {
                        Name = "Armenian"
                    }, 
                    new Language
                    {
                        Name = "Belarusian"
                    },
                    new Language
                    {
                        Name = "Bulgarian"
                    },
                    new Language
                    {
                        Name = "Chinese"
                    },
                    new Language
                    {
                        Name = "Croatian"
                    },
                    new Language
                    {
                        Name = "Czech"
                    },
                    new Language
                    {
                        Name = "Danish"
                    },
                    new Language
                    {
                        Name = "Dutch"
                    },
                    new Language
                    {
                        Name = "Estonian"
                    },
                    new Language
                    {
                        Name = "Finnish"
                    },
                    new Language
                    {
                        Name = "French"
                    },
                    new Language
                    {
                        Name = "Georgian"
                    },
                    new Language
                    {
                        Name = "German"
                    },
                    new Language
                    {
                        Name = "Greek"
                    },
                    new Language
                    {
                        Name = "Hebrew"
                    },
                    new Language
                    {
                        Name = "Hindi"
                    },
                    new Language
                    {
                        Name = "Hungarian"
                    },
                    new Language
                    {
                        Name = "Icelandic"
                    },
                    new Language
                    {
                        Name = "Indonesian"
                    },
                    new Language
                    {
                        Name = "Irish"
                    },
                    new Language
                    {
                        Name = "Italian"
                    },
                    new Language
                    {
                        Name = "Japanese"
                    },
                    new Language
                    {
                        Name = "Korean"
                    },
                    new Language
                    {
                        Name = "Latvian"
                    },
                    new Language
                    {
                        Name = "Lithuanian"
                    },
                    new Language
                    {
                        Name = "Macedonian"
                    },
                    new Language
                    {
                        Name = "Norwegian"
                    },
                    new Language
                    {
                        Name = "Persian"
                    },
                    new Language
                    {
                        Name = "Polish"
                    },
                    new Language
                    {
                        Name = "Portuguese"
                    },
                    new Language
                    {
                        Name = "Romanian"
                    },
                    new Language
                    {
                        Name = "Russian"
                    },
                    new Language
                    {
                        Name = "Serbian"
                    },
                    new Language
                    {
                        Name = "Slovak"
                    },
                    new Language
                    {
                        Name = "Slovenian"
                    },
                    new Language
                    {
                        Name = "Spanish"
                    },
                    new Language
                    {
                        Name = "Swedish"
                    },
                    new Language
                    {
                        Name = "Turkish"
                    },
                    new Language
                    {
                        Name = "Ukrainian"
                    },
                    new Language
                    {
                        Name = "Urdu"
                    },
                    new Language
                    {
                        Name = "Uzbek"
                    },
                    new Language
                    {
                        Name = "Vietnamese"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
