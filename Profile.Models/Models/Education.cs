using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class Education : BaseModel
    {
        public int ResumeId { get; set; }

        public int EducationLevelId { get; set; }

        public virtual EducationLevel EducationLevel { get; set; }

        [MaxLength(100)]
        public string EducationalInstitution { get; set; }

        [MaxLength(100)]
        public string Department { get; set; }

        [MaxLength(100)]
        public string Specialization { get; set; }

        public string YearOfAdmission { get; set; }

        public string YearOfGraduation { get; set; }
    }
}
