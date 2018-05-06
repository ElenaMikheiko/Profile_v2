using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Profile.Model.Infrastructure;

namespace Profile.Web.Controllers
{
    [Authorize(Roles = ProfilerRoles.Trainer)]
    public class TrainerController : Controller
    {
        public TrainerController()
        { }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}