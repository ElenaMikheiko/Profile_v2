using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Web.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "Email is required")]
        [RegularExpression(@"^\w+@\w+\.\w{2,4}$", ErrorMessage = "Please use format 'example@mail.com'")]
        //[EmailAddress]
        public string Email { get; set; }

        [Required ( ErrorMessage = "Password is required")]
        [RegularExpression(@"[a-zA-Z0-9]\w{3,11}$", ErrorMessage = "Password must be 4-12 symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
