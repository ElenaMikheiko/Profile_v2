using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class AdditionalInfo:BaseModel
    {
        [MaxLength(1000)]
        public string Text { get; set; }

        public int ResumeId { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
