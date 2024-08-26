using Microsoft.AspNetCore.Mvc;
using System;
using AwardProjectEntity.Base;

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


