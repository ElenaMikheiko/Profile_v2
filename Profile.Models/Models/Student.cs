using System;
using System.Collections.Generic;

namespace Profile.Model.Models
{
    public class Student : BaseModel
    {
        public int UserInfoId { get; set; }

        public virtual UserInfo UserInfo { get; set; }

        public string TrainerId { get; set; }

        public DateTime DateOfGraduation { get; set; }

        public int GraduationMark { get; set; }

        public virtual ICollection<StudentSkill> StudentSkills { get; set; }

    }
}
