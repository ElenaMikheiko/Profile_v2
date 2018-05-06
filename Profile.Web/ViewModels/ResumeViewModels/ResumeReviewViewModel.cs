using Profile.Model.Models;

namespace Profile.Web.ViewModels
{
    public class ResumeReviewViewModel
    {
        public UserInfo UserInfo { get; set; }

        public int ResumeId { get; set; }

        public string ResumeStatus { get; set; }

        public Stream Stream { get; set; }

        public Summary Summary { get; set; }

        public string [] Skills { get; set; }

        public ForeignLanguage [] ForeignLanguages { get; set; }

        public Education[] Educations { get; set; }

        public Course[] Courses { get; set; }

        public Exam[] Exams { get; set; }

        public Certificate[] Certificates { get; set; }

        public WorkExperience[] WorkExperience { get; set; }

        public Portfolio[] Portfolio { get; set; }

        public MilitaryStatus MilitaryStatus { get; set; }

        public AdditionalInfo AdditionalInfo { get; set; }

        public Recommendation[] Recommendations { get; set; }
    }
}
