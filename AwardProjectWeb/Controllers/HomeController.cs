using System.Linq.Expressions;
using AwardProjectEntity;
using AwardProjectService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility.Security;

namespace AwardProjectWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private UserService _userService;

        public HomeController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

