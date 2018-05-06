using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Profile.DataAccess.Data;
using Profile.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Profile.Service.Services.Interfaces;

namespace Profile.Service.Services
{
    public class StudentService : IStudentService
    {
        private ProfileDbContext _db;
        private UserManager<ApplicationUser> _userManager;

        public StudentService(ProfileDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task AddOrUpdateStudentAsync(Student student)
        {
            Student dbStudent = _db.Students.FirstOrDefault(s => s.Id == student.Id);

            if ( dbStudent != null )
            {
                dbStudent = student;
                _db.Students.Update(dbStudent);
            }
            else
            {
                await _db.Students.AddAsync(student);
            }
        }

        public async Task AddStream(Student student, Stream stream)
        {
            StudentStream studentStream = new StudentStream
            {
                StudentId = student.Id,
                StreamId = stream.Id
            };

          await _db.StudentStreams.AddAsync(studentStream);
        }

        public Student GetCurrentStudentByUserInfo(int userInfoId)
        {
            return _db.Students.FirstOrDefault(m => m.UserInfoId == userInfoId);
        }

        public Student GetStudentByResumeId(int resumeId)
        {
            return _db.Resume.Include(m => m.Student).FirstOrDefault(m => m.Id == resumeId).Student;
        }

        public IList<string> GetStudentEmailsByRoleName(string roleName)
        {
            IList<string> emails = new List<string>();
            IList<ApplicationUser> applicationUsers = _userManager.GetUsersInRoleAsync(roleName).GetAwaiter().GetResult();
            foreach (ApplicationUser applicationUser in applicationUsers)
            {
                emails.Add(applicationUser.Email);
            }

            return emails;
            
        }

        public IQueryable<Student> GetStudentsByTrainerId(string Id)
        {
            return _db.Students.Where(s => s.TrainerId == Id);
        }

        public bool IsExistStudent(int userInfoId)
        {
            return _db.Students.Any(s => s.UserInfoId == userInfoId);
        }

        public UserInfo GetStudentInfoByEmail(string userName)
        {
            return _db.UserInfo.Include(u => u.User).FirstOrDefault(u => u.Email == userName);
        }

        public UserInfo GetTrainer(Student student)
        {
            return _db.UserInfo.FirstOrDefault(ui => ui.UserId == student.TrainerId);
        }


        /// <summary>
        /// Returns all the students that are present in the database.
        /// </summary>
        /// <returns></returns>
        public IList<Student> GetAllStudents()
        {
            return _db.Students.ToList();
        }

        public UserInfo GetUserInfo(Student student)
        {
            return _db.UserInfo.FirstOrDefault(ui => ui.Id == student.UserInfoId);
        }
    }
}
