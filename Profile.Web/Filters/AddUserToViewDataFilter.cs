using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Profile.DataAccess.Data;
using System.Linq;
using System.Threading.Tasks;
using Profile.Web.Extensions;
using Profile.Model.Models;
using Profile.Model.Infrastructure;

namespace Profile.Web.Filters
{
    public class AddUserToViewDataFilter : ActionFilterAttribute
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ProfileDbContext _db;

        public AddUserToViewDataFilter(UserManager<ApplicationUser> userManager, ProfileDbContext context)
        {
            _userManager = userManager;
            _db = context;
        }

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                await base.OnResultExecutionAsync(context, next);
                return;
            }

            var viewResult = context.Result as ViewResult; //Check also for PartialViewResult and ViewComponentResult
            if (viewResult == null)
            {
                await base.OnResultExecutionAsync(context, next);
                return;
            }

            var userData = context.HttpContext.Session.Get<UserData>(ProfilerRoles.UserSessionKey);
            if (userData == null || userData.Email == null)
            {
                userData = new UserData();
                var user = _userManager.Users.FirstOrDefault(i => i.UserName == context.HttpContext.User.Identity.Name);
                UserInfo userInfo = _db.UserInfo.FirstOrDefault(ui => ui.UserId == user.Id);
                userData.Name = userInfo.EnName;
                userData.Surname = userInfo.EnSurname;
                userData.Email = userInfo.Email;
                userData.Role = (await _userManager.GetRolesAsync(user)).First();
                context.HttpContext.Session.Set(ProfilerRoles.UserSessionKey, userData);
            }            

            dynamic viewData = new DynamicViewData(() => viewResult.ViewData);
            viewData.User = userData;

            await base.OnResultExecutionAsync(context, next);
        }
    }
}

