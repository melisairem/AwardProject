using Microsoft.AspNetCore.Mvc;

namespace AwardProjectWeb.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}