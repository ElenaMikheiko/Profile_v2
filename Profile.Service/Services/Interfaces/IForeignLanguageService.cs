using Profile.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IForeignLanguageService
    {
        IEnumerable<ForeignLanguage> GetAllForeignLanguagesForResume (int resumeId);

        IEnumerable<Language> GetAllLanguages();

        IEnumerable<LanguageLevel> GetAllLanguageLevels();

        Task SaveForeignLanguagesAsync(int resumeId, Dictionary<int, int> languageLevelIdsByLanguageIds);
    }
}
