using Profile.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IForeingLanguageResumeService
    {
        Task SaveForeignLanguagesAndUpdateResumeAsync(Resume resume, Dictionary<int, int> languageLevelIdsByLanguageIds);
    }
}
