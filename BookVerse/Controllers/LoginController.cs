using Microsoft.AspNetCore.Mvc;

namespace BookVerse.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
