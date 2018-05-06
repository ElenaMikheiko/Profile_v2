using Microsoft.EntityFrameworkCore;
using Profile.DataAccess.Data;
using Profile.Model.Models;
using Profile.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public class SkillService : ISkillService
    {
        private ProfileDbContext _db;

        public SkillService(ProfileDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return _db.Skills.OrderBy(s => s.Name).ToList();
        }

        public async Task SaveSkillsAsync(int currentStudentId, string[] skills)
        {
            //Delete all student skills, if they are exist
            var studentSkills = _db.StudentSkills.Where(s => s.StudentId == currentStudentId).ToList();

            if (studentSkills.Count()!=0)
            {
                foreach (var stud in studentSkills)
                {
                    _db.StudentSkills.Remove(stud);
                }
            }

            //Add skill for current student
            foreach (var skill in skills)
            {
                var existingSkill = _db.Skills.FirstOrDefault(s => s.Name == skill);

                if (existingSkill!=null)
                {
                    // If the added skill has been removed above in this method, 
                    // we change EntityState from "Deleted" to "Modified" for this skill
                    var existingStudentSkill = studentSkills.FirstOrDefault(s=> s.SkillId == existingSkill.Id
                                                                            && s.StudentId == currentStudentId);
                    if (existingStudentSkill != null)
                    {
                        _db.Entry(existingStudentSkill).State = EntityState.Modified;
                    }
                    else
                    {
                        //If Skills are exist, add new record about Student and its skills
                        StudentSkill studentSkill = new StudentSkill
                        {
                            SkillId = existingSkill.Id,
                            StudentId = currentStudentId,
                        };

                        _db.StudentSkills.Add(studentSkill);
                    }
                }
                //If skill is added by user, add new skill to table Skill and add new record about Student and its skills
                else
                {
                    var Skill = new Skill
                    {
                        Name = skill
                    };
                    _db.Skills.Add(Skill);

                    StudentSkill studentSkill = new StudentSkill
                    {
                        SkillId = Skill.Id,
                        StudentId = currentStudentId,
                    };
                    _db.StudentSkills.Add(studentSkill);
                }
            }
        }

        public IEnumerable<string> GetAllSkillsForStudent(int studentId)
        {
            var skill = _db.StudentSkills.Include(l => l.Skill).Where(l => l.StudentId == studentId);
            return skill.Select(s => s.Skill.Name).ToArray();
        }

        public IEnumerable<string> GetDefaultSkillsByStream(int streamId)
        {
            var skill = _db.StreamSkills.Include(s => s.Skill).Where(s => s.StreamId == streamId);
            return skill.Select(s => s.Skill.Name).ToArray();
        }
    }
}
