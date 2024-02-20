using BookVerse.Data;
using BookVerse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore;

namespace BookVerse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<Book> allBooks = _db.Books.Include(b => b.Category).ToList();
            return View(allBooks);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {


            if (id == null || _db.Books == null)
            {
                return NotFound();
            }

            var ressource = _db.Books
                 .Include(b => b.Category)
                .FirstOrDefault(m => m.Id == id);
            if (ressource == null)
            {
                return NotFound();
            }

            return View(ressource);


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
