using Profile.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Web.ViewModels
{
    public class WorkExperienceViewModel
    {
        public bool ToPresent { get; set; }

        public string Organization { get; set; }

        public string Position { get; set; }

        public string Responsibilities { get; set; }

        public int SelectedStartYear { get; set; }

        public int SelectedEndYear { get; set; }

        public int SelectedStartMonth { get; set; }

        public int SelectedEndMonth { get; set; }

        public WorkExperienceViewModel()
        {
        }

        public WorkExperienceViewModel(WorkExperience workExperience)
        {
            SelectedStartMonth = workExperience.StartDate.Month;
            SelectedStartYear = workExperience.StartDate.Year;
            ToPresent = workExperience.ToPresent;
            SelectedEndMonth = workExperience.EndDate.HasValue ? workExperience.EndDate.Value.Month : 0;
            SelectedEndYear = workExperience.EndDate.HasValue ? workExperience.EndDate.Value.Year : 0;
            Position = workExperience.Position;
            Organization = workExperience.Organization;
            Responsibilities = workExperience.Responsibilities;
        }

        public WorkExperience ToWorkExperience()
        {
            WorkExperience workExperience = new WorkExperience
            {
                StartDate = new DateTime(SelectedStartYear, SelectedStartMonth, 1),
                ToPresent = ToPresent,
                Position = Position,
                Organization = Organization,
                Responsibilities = Responsibilities
            };

            if(!workExperience.ToPresent)
            {
                workExperience.EndDate = new DateTime(SelectedEndYear, SelectedEndMonth, 1);
            }

            return workExperience;            
        }
    }
}
