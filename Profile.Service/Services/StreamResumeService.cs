using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class StreamResumeService : IStreamResumeService
    {
        private readonly ProfileDbContext _dbContext;

        public IResumeService _resumeService => new ResumeService(_dbContext);

        public IStreamService _streamService => new StreamService(_dbContext);

        public StreamResumeService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveStreamAndUpdateResumeAsync(Resume resume, int currentStudentId, int objectiveId)
        {
            _resumeService.UpdateResume(resume);

            await _streamService.SaveStreamAsync(currentStudentId, objectiveId);
        }
    }
}
