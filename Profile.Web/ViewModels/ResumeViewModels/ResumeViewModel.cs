﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Profile.Model.Models;
using System.Collections.Generic;

namespace Profile.Web.ViewModels
{
    public class ResumeViewModel
    {
        public UserInfo UserInfo { get; set; }

        public int ResumeId { get; set; }

        public int CurrentResumeStep { get; set; }

        public string StreamFullName { get; set; }

        public string Summary { get; set; }

        #region For dropdownlist Skills

        public string [] Skills { get; set; }

        public List<Skill> SkillList { get; set; }
       
        #endregion

        #region For dropdownlist Language

        public List<Language> Languages { get; set; }

        public List<LanguageLevel> LanguageLevels { get; set; }

        public Dictionary<int,int> ForeignLanguages { get; set; }

        #endregion

        #region For dropdownlist Years, EducationLevel, Months

        public List<EducationLevel> EducationLevels { get; set; }

        public Dictionary<int,string> Months { get; set; }

        public List<int> Years { get; set; }

        #endregion

        public Education [] Educations { get; set; }

        public Course[] Courses { get; set; }

        public Exam[] Exams { get; set; }

        public Certificate[] Certificates { get; set; }

        public WorkExperienceViewModel [] WorkExperiences { get; set; }

        public Portfolio[] Portfolios { get; set; }

        public MilitaryStatus MilitaryStatus { get; set; }

        public AdditionalInfo AdditionalInfo { get; set; }

        public Recommendation[] Recommendations { get; set; }
    }
}
