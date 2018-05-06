using Microsoft.EntityFrameworkCore;
using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class ForeignLanguageService : IForeignLanguageService
    {
        private ProfileDbContext _db;

        public ForeignLanguageService(ProfileDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ForeignLanguage> GetAllForeignLanguagesForResume(int resumeId)
        {
            return _db.ForeignLanguages.Include(l=>l.Language)
                                       .Include(l=>l.LanguageLevel)
                                       .Where(l => l.ResumeId == resumeId).ToList();
        }

        public IEnumerable<LanguageLevel> GetAllLanguageLevels()
        {
            return _db.LanguageLevels;
        }

        public IEnumerable<Language> GetAllLanguages()
        {
            return _db.Languages.OrderBy(l => l.Name).ToList();
        }

        public async Task SaveForeignLanguagesAsync(int resumeId, Dictionary<int, int> languageLevelIdsByLanguageIds)
        {
            //if there are foreign languages for current CV, to delete them
            var languages = _db.ForeignLanguages.Where(s => s.ResumeId == resumeId).ToList();
            if (languages.Count()!=0)
            {
                foreach (var lang in languages)
                {
                    _db.ForeignLanguages.Remove(lang);
                }
            }
            foreach (var languageItem in languageLevelIdsByLanguageIds)
            {
                //If the added foreign language has been removed above in this method,
                //we change EntityState from "Deleted" to "Modified" for this foreign language
                var existingForeignLanguage = languages.FirstOrDefault(l => l.ResumeId == resumeId 
                                                                    && l.LanguageId == languageItem.Key
                                                                    && l.LanguageLevelId == languageItem.Value);
                if (existingForeignLanguage != null)
                {
                    _db.Entry(existingForeignLanguage).State = EntityState.Modified;
                }
                else
                {
                    ForeignLanguage foreignLanguage = new ForeignLanguage
                    {
                        ResumeId = resumeId,
                        LanguageId = languageItem.Key,
                        LanguageLevelId = languageItem.Value
                    };

                    _db.ForeignLanguages.Add(foreignLanguage);
                }
            }
        }
    }
}