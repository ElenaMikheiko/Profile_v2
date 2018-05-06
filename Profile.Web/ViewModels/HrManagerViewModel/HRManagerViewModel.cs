using System;
using System.Collections.Generic;
using Profile.Model.Models;

namespace Profile.Web.ViewModels.HrManagerViewModel
{
    public class HrManagerViewModel 
    {
        public IList<TableRow> TableData { get; set; }
    }

    public class TableRow
    {
        public string DateOfBirth { get; set; }

        public string DateOfGraduation { get; set; } 

        public string PhoneNumber { get; set; }

        public Stream Stream { get; set; }

        public Student Student { get; set; }

        public string TrainerEmail { get; set; }

        public UserInfo UserInfo { get; set; }

    }
}
