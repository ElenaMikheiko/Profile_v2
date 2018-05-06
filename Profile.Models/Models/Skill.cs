using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class Skill : BaseModel
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<StudentSkill> StudentSkills { get; set; }

        public virtual ICollection<StreamSkill> StreamSkills { get; set; }

    }
}
