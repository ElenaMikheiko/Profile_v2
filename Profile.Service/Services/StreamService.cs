using Microsoft.EntityFrameworkCore;
using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class StreamService : IStreamService
    {
        private ProfileDbContext _db;

        public StreamService(ProfileDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Stream> GetAllStreams()
        {
            return _db.Streams.OrderBy(o => o.StreamFullName).ToList();        }

        public Stream GetStreamByStudentId(int studentId)
        {
            return _db.Streams.FirstOrDefault(s => s.Id == _db.StudentStreams.FirstOrDefault(m => m.StudentId == studentId).StreamId);
        }

        public Stream GetStreamByShortName(string streamShortName)
        {
            return _db.Streams.FirstOrDefault(s => s.StreamShortName == streamShortName);
        }

        public async Task SaveStreamAsync(int currentStudentId, int streamId)
        {
            var studentStream = _db.StudentStreams.FirstOrDefault(x => x.StudentId == currentStudentId);
            if (studentStream != null)
            {
                _db.StudentStreams.Remove(studentStream);
            }

            // If the added stream has been removed above in this method, 
            // we change EntityState from "Deleted" to "Modified" for this stream
            var existingStudentStream = _db.StudentStreams.FirstOrDefault(s => s.StudentId == currentStudentId
                                                                           && s.StreamId == streamId);
            if (existingStudentStream != null)
            {
                _db.Entry(existingStudentStream).State = EntityState.Modified;
            }
            else
            {
                //Create new StudentStream
                var newStudentStream = new StudentStream
                {
                    StudentId = currentStudentId,
                    StreamId = streamId
                };
                _db.StudentStreams.Add(newStudentStream);
            }
        }

        public Stream GetStreamByFullName(string streamFullName)
        {
            return _db.Streams.FirstOrDefault(s => s.StreamFullName == streamFullName);
        }
    }
}