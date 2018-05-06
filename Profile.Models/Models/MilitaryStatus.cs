using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class MilitaryStatus : BaseModel
    {
        [MaxLength(20)]
        public string Status { get; set; }

        public int ResumeId { get; set; }

        public virtual Resume Resume { get; set; }

    }
}
