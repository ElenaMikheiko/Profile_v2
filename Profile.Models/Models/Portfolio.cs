using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class Portfolio : BaseModel
    {
        public int ResumeId { get; set; }

        [MaxLength(100)]
        public string Link { get; set; }
    }
}