using Microsoft.AspNetCore.Mvc;

namespace MyBook.Controllers
{
    public class BookController : Controller
    {
        // GET
        public IActionResult Book()
        {
            return View();
        }
    }
}