using BookVerse.Data;
using BookVerse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace BookVerse.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            List<Book> objProduct = _db.Books.Include(p => p.Category).ToList();
            return View(objProduct);


        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_db.Categories, "Id", "Name");
            var book = new Book
            {
                Posteddate = DateTime.Now
            };
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book resource)
        {

            if (resource.ImageFile != null)
            {
                var folder = "images/";
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + resource.ImageFile.FileName;
                var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);


                using (var fileStream = new FileStream(Path.Combine(serverFolder, uniqueFileName), FileMode.Create))
                {
                    await resource.ImageFile.CopyToAsync(fileStream);
                }

                resource.ImageName = Path.Combine(folder, uniqueFileName);
            }

            _db.Books.Add(resource);
            _db.SaveChanges();
            return RedirectToAction("Index");


            return View(resource);


        }

    }
}
