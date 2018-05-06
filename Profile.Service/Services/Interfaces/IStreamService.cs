using Profile.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IStreamService
    {
        Stream GetStreamByStudentId(int studentId);

        Stream GetStreamByShortName(string streamShortName);

        Stream GetStreamByFullName(string streamFullName);

        IEnumerable<Stream> GetAllStreams();

        Task SaveStreamAsync(int currentStudentId, int objectiveId);
    }
}
