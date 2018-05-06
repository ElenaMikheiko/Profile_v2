using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class Course:BaseModel
    {
        public int ResumeId { get; set; }

        [MaxLength(100)]
        public string Organization { get; set; }

        [MaxLength(100)]
        public string Specialization { get; set; }

        [MaxLength(100)]
        public string YearOfGraduation { get; set; }
    }
}
