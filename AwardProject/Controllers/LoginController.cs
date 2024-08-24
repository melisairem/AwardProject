using Microsoft.AspNetCore.Mvc;

namespace AwardProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}