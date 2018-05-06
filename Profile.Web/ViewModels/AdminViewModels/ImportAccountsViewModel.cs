using System.Collections.Generic;

namespace Profile.Web.ViewModels.AdminViewModels
{
    public class ImportAccountsViewModel
    {
        public IList<string> studentEmails;
        public IList<string> trainerEmails;

        public ImportAccountsViewModel()
        {
            studentEmails = new List<string>();
            trainerEmails = new List<string>();
        }

        public string ApiKey { get; set; }
    }
}
