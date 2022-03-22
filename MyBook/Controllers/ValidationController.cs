using Microsoft.AspNetCore.Mvc;

namespace MyBook.Controllers
{
    public class ValidationController : Controller
    {
        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
    }
}
