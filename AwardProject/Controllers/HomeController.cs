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
        List<User> users = _context.User.ToList();
        //_context.User.Add(new User() { Name = "Test", Email = "", Surname = "Test3", Password = "AAA" });
        //_context.SaveChanges();
        return View(users);
    }

}


