using System.ComponentModel.DataAnnotations;

namespace Profile.Model.Models
{
    public class ForeignLanguage 
    {
        public int ResumeId { get; set; }

        public int LanguageId{ get; set; }

        [MaxLength(20)]
        public virtual Language Language { get; set; }

        public int LanguageLevelId { get; set; }

        [MaxLength(30)]
        public virtual LanguageLevel LanguageLevel { get; set; }
    }
}
