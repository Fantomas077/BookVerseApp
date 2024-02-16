using System.Collections.Generic;
using BookVerse.Data;
using BookVerse.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BookVerse.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Category> objList = _db.Categories.ToList();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (_db.Categories.Any(c => c.Name == obj.Name))
                {
                    ModelState.AddModelError("Name", $"{obj.Name} already exists.");
                    return View();
                }
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Category? CategoryFromDb = _db.Categories.Find(Id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);

        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (_db.Categories.Any(c => c.Name == obj.Name))
                {
                    ModelState.AddModelError("Name", $"{obj.Name} already exists.");
                    return View();
                }
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);


        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Category? CategoryFromDb = _db.Categories.Find(Id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);

        }
        [HttpPost]
        public IActionResult Delete(Category obj)
        {
            if (ModelState.IsValid)
            {

                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Remove successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
