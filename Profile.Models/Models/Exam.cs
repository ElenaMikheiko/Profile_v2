using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class Exam : BaseModel
    {
        public int ResumeId { get; set; }

        [MaxLength(100)]
        public string ExamName { get; set; }

        [MaxLength(100)]
        public string Organization { get; set; }

        public string Specialization { get; set; }

        public string YearOfAttestation { get; set; }
    }
}
