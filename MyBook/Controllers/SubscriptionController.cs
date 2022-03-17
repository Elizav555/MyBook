using Microsoft.AspNetCore.Mvc;

namespace MyBook.Controllers
{
    public class SubscriptionController : Controller
    {
        // GET
        public IActionResult Subscription()
        {
            return View();
        }
    }
}