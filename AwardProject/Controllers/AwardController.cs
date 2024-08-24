using AwardProject.Models;
using AwardProject.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace AwardProject.Controllers
{
    public class AwardController : Controller
    {
        private readonly ModelContext _context;

        public AwardController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            List<Award> awards = _context.Award.ToList();
            return View(awards);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Award award)
        {
            _context.Award.Add(award);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            Award award = _context.Award.Find(id)!;
            return View(award);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Award award)
        {
            _context.Award.Update(award);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            Award? award = _context.Award.Find(id);
            if (award != null)
            {
                _context.Award.Remove(award);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
