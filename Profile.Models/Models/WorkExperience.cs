using System;
using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class WorkExperience : BaseModel
    {
        public int ResumeId { get; set; }

        public DateTime StartDate { get; set; }

        public bool ToPresent { get; set; }

        public DateTime? EndDate { get; set; }

        [MaxLength(100)]
        public string Organization { get; set; }

        [MaxLength(100)]
        public string Position { get; set; }

        [MaxLength(1000)]
        public string Responsibilities { get; set; }
    }
}
