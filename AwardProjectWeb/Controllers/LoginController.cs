using AwardProjectEntity;
using AwardProjectService;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Utility.Security;

namespace AwardProjectWeb.Controllers
{
    public class LoginController : Controller
    {

        private UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IFormCollection collection)
        {
            string email = collection["Email"];
            string password = collection["Password"];

            //string hashedPasssword = PasswordHash.Hash(password);  hashlenmemiş şifreleri hash li kaydetmek içindi

            User? user = _userService.GetAll(predicates: new List<Expression<Func<User, bool>>>
            {
                user => user.Email == email
            }).FirstOrDefault();

            string errorMessage;
            if (user != null)
            {
                bool isCorrect = PasswordHash.Verify(user.Password, password);

                if (isCorrect)
                {
                    return RedirectToAction("Index",controllerName: "Home");
                }
                else
                {
                    errorMessage = "Kullanıcı adı veya şifre hatalı";
                }
            }
            else
            {
                errorMessage = "Kullanıcı adı veya şifre hatalı";
            }

            ViewData["ErrorMessage"] = errorMessage;
            return View();
        }
    }
}