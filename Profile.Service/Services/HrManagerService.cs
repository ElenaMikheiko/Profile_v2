using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;

namespace Profile.Service.Services
{
    public class HrManagerService : IHrManagerService
    {
        private readonly ProfileDbContext _db;

        public HrManagerService(ProfileDbContext db)
        {
            _db = db;
        }

        // Get's list of students info
        public async Task<ICollection<StudentStream>> GetStudentStreamUserInfos()
        {
            return await _db.StudentStreams
                .Include(f => f.Student)
                .ThenInclude(q => q.UserInfo).Where(s => s.Student.UserInfoId == s.Student.UserInfo.Id)//.Where(u => u.StreamId == 2)//.Where(s => s.StudentId.Equals(s.Student.Id))
                .Include(r => r.Stream)
                .ToListAsync();
        }
    }
}
