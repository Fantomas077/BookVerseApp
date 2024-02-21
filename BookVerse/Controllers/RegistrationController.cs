using BookVerse.Data;
using BookVerse.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
