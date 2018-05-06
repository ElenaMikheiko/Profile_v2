using Profile.DataAccess.Data;
using Profile.Model.Models;
using System.Collections.Generic;
using System.Linq;
 
namespace Profile.Web.Initializers
{
    public static class SkillsInitializer
    {
        public static void Initialize(ProfileDbContext context)
        {
            IList<Skill> skills = new List<Skill> {
                #region Default skills       
                    new Skill
                    {
                        Name= "Java Core"
                    },
                    new Skill
                    {
                        Name = "Android SDK"
                    },
                    new Skill
                    {
                        Name = "RxJava"
                    },
                    new Skill
                    {
                        Name = "RxAndroid"
                    },
                    new Skill
                    {
                        Name = "Java"
                    },
                    new Skill
                    {
                        Name = "Selenium Webdriver"
                    },
                    new Skill
                    {
                        Name = "XML"
                    },
                    new Skill
                    {
                        Name = "HTML"
                    },
                    new Skill
                    {
                        Name = "CSS"
                    },
                    new Skill
                    {
                        Name = "Analyzing Requirements"
                    },
                    new Skill
                    {
                        Name = "Vision&Scope"
                    },
                    new Skill
                    {
                        Name = "BPMN"
                    },
                    new Skill
                    {
                        Name = "С++"
                    },
                    new Skill
                    {
                        Name = "Qt Framework"
                    },
                    new Skill
                    {
                        Name = "STL"
                    },
                    new Skill
                    {
                        Name = "Servlets"
                    },
                    new Skill
                    {
                        Name = "Spring"
                    },
                    new Skill
                    {
                        Name = "С#"
                    },
                    new Skill
                    {
                        Name = "ASP.NET MVC"
                    },
                    new Skill
                    {
                        Name = "SOLID"
                    },
                    new Skill
                    {
                        Name = "Swift"
                    },
                    new Skill
                    {
                        Name = "Xcode"
                    },
                    new Skill
                    {
                        Name = "PHP"
                    },
                    new Skill
                    {
                        Name = "Symfony"
                    },
                    new Skill
                    {
                        Name = "MySQL"
                    },
                    new Skill
                    {
                        Name = "Python"
                    },
                    new Skill
                    {
                        Name = "Django"
                    },
                    new Skill
                    {
                        Name = "UnitTest"
                    },
                    new Skill
                    {
                        Name = "Linux"
                    },
                    new Skill
                    {
                        Name = "Automation"
                    },
                    new Skill
                    {
                        Name = "Functional testing"
                    },
                    new Skill
                    {
                        Name = "TestRail"
                    },
                    new Skill
                    {
                        Name = "Jira"
                    },
                    new Skill
                    {
                        Name = "Adobe Photoshop"
                    },
                    new Skill
                    {
                        Name = "Adobe Illustrator"
                    },
                    new Skill
                    {
                        Name = "Axure"
                    },
                #endregion

                #region Recommended skills
                    new Skill
                    {
                        Name = "Android API"
                    },
                    new Skill
                    {
                        Name = "REST"
                    },
                    new Skill
                    {
                        Name = "Retrofit"
                    },
                    new Skill
                    {
                        Name = "Android studio"
                    },
                    new Skill
                    {
                        Name = "ButterKnife"
                    },
                    new Skill
                    {
                        Name = "SQLite"
                    },
                    new Skill
                    {
                        Name = "Social Network"
                    },
                    new Skill
                    {
                        Name = "C++"
                    },
                    new Skill
                    {
                        Name = "Git"
                    },
                    new Skill
                    {
                        Name = "Confluence"
                    },
                    new Skill
                    {
                        Name = "Scrum"
                    },
                    new Skill
                    {
                        Name = "Agile"
                    },
                    new Skill
                    {
                        Name = "Software Development Methodologies"
                    },
                    new Skill
                    {
                        Name = "Software Development Processes"
                    },
                    new Skill
                    {
                        Name = "English"
                    },
                    new Skill
                    {
                        Name = "Jenkins"
                    },
                    new Skill
                    {
                        Name = "Testlink"
                    },
                    new Skill
                    {
                        Name = "SOAP UI"
                    },
                    new Skill
                    {
                        Name = "Test Plan"
                    },
                    new Skill
                    {
                        Name = "Test case"
                    },
                    new Skill
                    {
                        Name = "Manual testing"
                    },
                    new Skill
                    {
                        Name = "Regression testing"
                    },
                    new Skill
                    {
                        Name = "UML"
                    },
                    new Skill
                    {
                        Name = "User story"
                    },
                    new Skill
                    {
                        Name = "Prototyping"
                    },
                    new Skill
                    {
                        Name = "Diagramming"
                    },
                    new Skill
                    {
                        Name = "Modelling Tools"
                    },
                    new Skill
                    {
                        Name = "Presentation techniques"
                    },
                    new Skill
                    {
                        Name = "Software requirements specification"
                    },
                    new Skill
                    {
                        Name = "Boost"
                    },
                    new Skill
                    {
                        Name = "JavaScript"
                    },
                    new Skill
                    {
                        Name = "Design patterns"
                    },
                    new Skill
                    {
                        Name = "MultiThread programming"
                    },
                    new Skill
                    {
                        Name = "OOP"
                    },
                    new Skill
                    {
                        Name = "Bootstrap"
                    },
                    new Skill
                    {
                        Name = "Webpack"
                    },
                    new Skill
                    {
                        Name = "Angular"
                    },
                    new Skill
                    {
                        Name = "SASS"
                    },
                    new Skill
                    {
                        Name = "LESS"
                    },
                    new Skill
                    {
                        Name = "ReactJS"
                    },
                    new Skill
                    {
                        Name = "JSON"
                    },
                    new Skill
                    {
                        Name = "Babel"
                    },
                    new Skill
                    {
                        Name = "SDLC"
                    },
                    new Skill
                    {
                        Name = "Hibernate"
                    },
                    new Skill
                    {
                        Name = "JSP"
                    },
                    new Skill
                    {
                        Name = "JBoss"
                    },
                    new Skill
                    {
                        Name = "Web Services"
                    },
                    new Skill
                    {
                        Name = "SQL"
                    },
                    new Skill
                    {
                        Name = "REST API"
                    },
                    new Skill
                    {
                        Name = "JQuery"
                    },
                    new Skill
                    {
                        Name = "Entity Framework"
                    },
                    new Skill
                    {
                        Name = "MS SQL"
                    },
                    new Skill
                    {
                        Name = "NoSQL"
                    },
                    new Skill
                    {
                        Name = "iOS"
                    },
                    new Skill
                    {
                        Name = "Objective-C"
                    },
                    new Skill
                    {
                        Name = "Cocoa Touch"
                    },
                    new Skill
                    {
                        Name = "Core Data"
                    },
                    new Skill
                    {
                        Name = "MVC"
                    },
                    new Skill
                    {
                        Name = "Redis"
                    },
                    new Skill
                    {
                        Name = "Drupal"
                    },
                    new Skill
                    {
                        Name = "Flask"
                    },
                    new Skill
                    {
                        Name = "Tornado"
                    },
                    new Skill
                    {
                        Name = "RabbitMQ"
                    },
                    new Skill
                    {
                        Name = "Robot framework"
                    },
                    new Skill
                    {
                        Name = "Nginx"
                    },
                    new Skill
                    {
                        Name = "PostgreSQL"
                    },
                    new Skill
                    {
                        Name = "АPI testing"
                    },
                    new Skill
                    {
                        Name = "Black Box testing"
                    },
                    new Skill
                    {
                        Name = "GUI testing"
                    },
                    new Skill
                    {
                        Name = "Test strategy development"
                    },
                    new Skill
                    {
                        Name = "Requirements Testing"
                    },
                    new Skill
                    {
                        Name = "Sketch"
                    },
                    new Skill
                    {
                        Name = "CorelDRAW"
                    },
                    new Skill
                    {
                        Name = "UI"
                    },
                    new Skill
                    {
                        Name = "UX"
                    },
                    new Skill
                    {
                        Name = "Responsive design"
                    },
                    new Skill
                    {
                        Name = "Mobile design"
                    },
                    new Skill
                    {
                        Name = "Web design"
                    },
                    new Skill
                    {
                        Name = "Usability"
                    }

                    #endregion
            };

            foreach (Skill skill in skills)
            {
                var existingSkill = context.Skills.FirstOrDefault(s => s.Name == skill.Name);
                if (existingSkill == null)
                {
                    context.Skills.Add(skill);
                }
            }

            context.SaveChanges();
        }
    }
}