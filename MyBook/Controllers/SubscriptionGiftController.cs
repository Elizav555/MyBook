using Microsoft.AspNetCore.Mvc;

namespace MyBook.Controllers
{
    public class SubscriptionGiftController : Controller
    {
        // GET
        public IActionResult SubscriptionGift()
        {
            return View();
        }
    }
}