using Microsoft.AspNetCore.Mvc;

namespace MyBook.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Author()
        {
            return View();
        }
    }
}
