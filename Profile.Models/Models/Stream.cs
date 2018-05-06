using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class Stream:BaseModel
    {
        [MaxLength(100)]
        public string StreamFullName { get; set; }
        [MaxLength(100)]
        public string StreamShortName { get; set; }

        public virtual ICollection<StreamSkill> StreamSkills { get; set; }

    }
}
