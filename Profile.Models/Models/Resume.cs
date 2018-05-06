using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class Resume : BaseModel
    {
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public virtual ICollection<Portfolio> Portfolio { get; set; }

        public virtual ICollection<ForeignLanguage> Languages { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Education> Educations { get; set; }

        public virtual ICollection<WorkExperience> Experience { get; set; }

        public virtual ICollection<Recommendation> Recommendations{ get; set; }

        public virtual ICollection<Exam> Test { get; set; }

        public virtual MilitaryStatus MilitaryStatus { get; set; }

        public virtual Summary Summary { get; set; }

        public virtual AdditionalInfo AdditionalInfo { get; set; }

        public int CurrentStep { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }
    }
}