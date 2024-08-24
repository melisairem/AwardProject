using Microsoft.AspNetCore.Mvc;
using System;
using AwardProject.Models;
using AwardProject.Models.Base;

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


