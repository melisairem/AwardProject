﻿using AwardProjectEntity;
using AwardProjectService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AwardProjectWeb.Controllers
{
    [Authorize]
    public class AwardController : Controller
    {
        private readonly AwardService _awardService;
        private readonly CategoryService _categoryService;

        public AwardController(AwardService awardService, CategoryService categoryService)
        {
            _awardService = awardService;
            _categoryService = categoryService;
        }

        public IActionResult List()
        {
            List<Award> awards = _awardService.GetAll(new List<string>
            {
                nameof(Award.Category)

            }).ToList();
            return View(awards);
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            List<Category> categories = _categoryService.GetAll().ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Award award)
        {
            _awardService.Add(award);
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            Award award = _awardService.GetById(id);
            List<Category> categories = _categoryService.GetAll().ToList();
            ViewBag.Categories = categories;
            return View(award);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Award award)
        {
            _awardService.Update(award);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            _awardService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
