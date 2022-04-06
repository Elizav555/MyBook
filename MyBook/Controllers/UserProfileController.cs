using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBook.Controllers
{
    [Authorize(Policy = "ReadersOnly")]
    public class UserProfileController : Controller
    {
        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult EditSubscription()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult NonSubscription()
        {
            return View();
        }
    }
}
