using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services;
using Profile.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class ForeignLanguageResumeService : IForeingLanguageResumeService
    {
        private readonly ProfileDbContext _dbContext;

        public IResumeService _resumeService => new ResumeService(_dbContext);

        public IForeignLanguageService _foreignLanguageService => new ForeignLanguageService(_dbContext);

        public ForeignLanguageResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveForeignLanguagesAndUpdateResumeAsync(Resume resume, Dictionary<int, int> languageLevelIdsByLanguageIds)
        {
            _resumeService.UpdateResume(resume);

            await _foreignLanguageService.SaveForeignLanguagesAsync(resume.Id, languageLevelIdsByLanguageIds);
        }
    }
}
