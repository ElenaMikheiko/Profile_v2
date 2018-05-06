using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class Recommendation : BaseModel
    {
        public int ResumeId { get; set; }

        [MaxLength(100)]
        public string PersonName { get; set; }

        [MaxLength(100)]
        public string PersonPositionAndOrganization { get; set; }

        [MaxLength(1000)]
        public string ContactAndLetterLink { get; set; }
    }
}
