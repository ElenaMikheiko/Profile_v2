using Profile.DataAccess.Data;
using Profile.Model.Models;
using System.Linq;

namespace Profile.DataAccess.Initializers
{
    public static class StreamSkillsInitilizer
    {
        public static void Initialize(ProfileDbContext context)
        {
            if (!context.StreamSkills.Any())
            {

                context.StreamSkills.AddRange(

                #region Skills for Android Developer (AD) 
                    
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "AD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Java Core")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "AD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Android SDK")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "AD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "RxJava")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "AD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "RxAndroid")
                },

                #endregion

                #region Skills for Java Automated Testing (AT) 

                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "AT"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Java")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "AT"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Selenium Webdriver")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "AT"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "XML")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "AT"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "HTML")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "AT"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "CSS")
                },

                #endregion

                #region Skills for Business Analyst (BA) 

                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "BA"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Analyzing Requirements")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "BA"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Vision&Scope")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "BA"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "BPMN")
                },

                #endregion

                #region Skills for C++ Developer (CD) 

                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "CD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "С++")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "CD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Qt Framework")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "CD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "STL")
                },

                #endregion

                #region Skills for Front-end Developer (FD) 

                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "FD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "HTML")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "FD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "CSS")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "FD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "JavaScript")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "FD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "jQuery")
                },

                #endregion

                #region Skills for Java Developer (JD) 

                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "JD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Java Core")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "JD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Servlets")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "JD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Spring")
                },

                #endregion

                #region Skills for ASP.NET Developer (ND) 

                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "ND"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "С#")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "ND"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "ASP.NET MVC")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "ND"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "SOLID")
                },

                #endregion

                #region Skills for IOS Developer (ID) 

                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "ID"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Swift")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "ID"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Xcode")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "ID"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "SOLID")
                },

                #endregion

                #region Skills for PHP Developer (PD) 

                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "PD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "PHP")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "PD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Symfony")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "PD"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "MySQL")
                },

                #endregion

                #region Skills for Python Developer (PT) 

                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "PT"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Python")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "PT"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Django")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "PT"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "UnitTest")
                },

                #endregion

                #region Skills for Python Automated Testing (PT2) 

                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "PT2"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Python")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "PT2"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Linux")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "PT2"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Automation")
                },

                #endregion

                #region Skills for Software Testing (ST) 

                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "ST"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Functional testing")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "ST"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "TestRail")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "ST"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Jira")
                },

                #endregion

                #region Skills for UI/UX Designer (UI/UX) 

                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "UI/UX"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Adobe Photoshop")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "UI/UX"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Adobe Illustrator")
                },
                new StreamSkill
                {
                    Stream = context.Streams.FirstOrDefault(s => s.StreamShortName == "UI/UX"),
                    Skill = context.Skills.FirstOrDefault(sk => sk.Name == "Axure")
                }

                #endregion

            );

                context.SaveChanges();
            }
        }
    }
}