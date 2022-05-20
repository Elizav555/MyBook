using Microsoft.AspNetCore.Mvc;

namespace MyBook.Controllers
{
    public class ModalsController : Controller
    {
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Successful()
        {
            return View();
        }
    }
}
