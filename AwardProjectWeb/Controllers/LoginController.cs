using AwardProjectEntity;
using AwardProjectService;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Utility.Auth;
using Utility.Model.Auth;
using Utility.Security;

namespace AwardProjectWeb.Controllers
{
    public class LoginController : Controller
    {

        private UserService _userService;
        private ImageService _imageService;

        public LoginController(UserService userService, ImageService imageService)
        {
            _userService = userService;
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var logo = _imageService.GetAll().FirstOrDefault();
            if (logo != null)
            {
                ViewData["LogoPath"] = logo.Path; 
            }
            else
            {
                ViewData["LogoPath"] = "/images/default-logo.png";
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IFormCollection collection)
        {
            string email = collection["Email"];
            string password = collection["Password"];

            //string hashedPasssword = PasswordHash.Hash(password);  //hashlenmemiş şifreleri hash li kaydetmek içindi

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
                    AuthenticationModel authenticationModel = new AuthenticationModel(user.Id, user.Email, user.Name, user.Surname, user.UserRole);
                    AuthenticationHelper.SignIn(authenticationModel);
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

            
            var logo = _imageService.GetAll().FirstOrDefault();
            if (logo != null)
            {
                ViewData["LogoPath"] = logo.Path;
            }
            else
            {
                ViewData["LogoPath"] = "/images/default-logo.png";
            }

            return View();
        }
    }
}