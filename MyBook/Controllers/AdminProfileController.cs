using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBook.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
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
