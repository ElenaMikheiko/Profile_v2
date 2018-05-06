using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class EducationLevel:BaseModel
    {
        [MaxLength(100)]
        public string Level { get; set; }
    }
}
