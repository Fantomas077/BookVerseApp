using BookVerse.Data;
using BookVerse.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookVerse.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RegistrationController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Registration model)
        {

            if (_db.Registrations.Any(c => c.Email == model.Email))
            {
                ModelState.AddModelError(nameof(Registration.Email), $"{model.Email} already exists.");
            }

            if (ModelState.IsValid)
            {
                _db.Registrations.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index", "LogIn");
            }


            return View(model);
        }
    }
}
