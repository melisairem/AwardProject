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
        private ImageService _imageService;

        public LoginController(UserService userService, ImageService imageService)
        {
            _userService = userService;
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            // Veritabanından logo bilgisini çek
            var logo = _imageService.GetAll().FirstOrDefault(); // İlk logoyu çekiyoruz
            if (logo != null)
            {
                ViewData["LogoPath"] = logo.Path; // Logonun yolunu ViewData'ya ekliyoruz
            }
            else
            {
                ViewData["LogoPath"] = "/images/default-logo.png"; // Varsayılan bir logo belirledik
            }

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

            // Logoyu tekrar ViewData'ya ekle
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