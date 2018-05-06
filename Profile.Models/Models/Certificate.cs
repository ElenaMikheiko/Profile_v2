using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class Certificate:BaseModel
    {
        public string Organization { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public string YearOfAttestation { get; set; }

        [MaxLength(100)]
        public string Link { get; set; }

        public int ResumeId { get; set; }
    }
}
