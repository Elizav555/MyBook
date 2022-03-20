using Microsoft.AspNetCore.Mvc;

namespace MyBook.Controllers
{
    public class AdminProfileController : Controller
    {
        public IActionResult EditAuthor()
        {
            return View();
        }

        public IActionResult EditBook()
        {
            return View();
        }

        public IActionResult EditUser()
        {
            return View();
        }

        public IActionResult EditBookPlace()
        {
            return View();
        }

        public IActionResult EditSubscription()
        {
            return View();
        }
    }
}
