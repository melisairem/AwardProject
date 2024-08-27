using AwardProjectEntity;
using AwardProjectService;
using Microsoft.AspNetCore.Mvc;

namespace AwardProjectWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        //[Route("user-list")] sayfanın adına route tanımı yapabiliriz
        public IActionResult List()
        {
            List<User> users = _userService.GetAll().ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(User user)
        {
            _userService.Add(user);
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            User? user = _userService.GetById(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
           _userService.Update(user);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            User? user = _userService.GetById(id);
            if (user != null)
            {
                _userService.Delete(id);
            }
            return RedirectToAction("List");
        }
    }
}