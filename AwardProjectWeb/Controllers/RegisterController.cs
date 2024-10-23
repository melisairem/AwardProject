using AwardProjectEntity;
using AwardProjectService;
using Microsoft.AspNetCore.Mvc;
using Utility.Auth;
using Utility.Model.Auth;

namespace AwardProjectWeb.Controllers
{
    public class RegisterController : Controller
    {

        private UserService _userService;
        private ImageService _imageService;

        public RegisterController(UserService userService, ImageService imageService)
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
            string name = collection["name"];
            string surname = collection["surname"];
            string email = collection["email"];
            string password = collection["password"];


            User user = new User
            {
                Name = name,
                Surname = surname,
                Email = email,
                Password = password, 
                UserRole = "Client" 
            };

            try
            {
                _userService.Add(user);

                AuthenticationModel authenticationModel = new AuthenticationModel(user.Id, user.Email, user.Name, user.Surname, user.UserRole);
                AuthenticationHelper.SignIn(authenticationModel);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;

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
}