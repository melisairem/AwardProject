using System.Linq.Expressions;
using AwardProjectEntity;
using AwardProjectService;
using Microsoft.AspNetCore.Mvc;
using Utility.Security;

namespace AwardProjectWeb.Controllers;

public class HomeController : Controller
{
    private UserService _userService;

    public HomeController(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        string email = "melisa@gmail.com";
        string password = "321";

        User user = _userService.GetAll(predicates: new List<Expression<Func<User, bool>>>
        {
            i => i.Email == email
        }).FirstOrDefault();

        if (user != null)
        {
            bool isCorrectPassword = PasswordHash.Verify(user.Password, password);
        }
        
        return View();
    }
}