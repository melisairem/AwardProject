using AwardProjectEntity.Base;
using Microsoft.AspNetCore.Mvc;

namespace AwardProjectWeb.Controllers;

public class HomeController : Controller
{
    private readonly ModelContext _context;

    public HomeController(ModelContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

}