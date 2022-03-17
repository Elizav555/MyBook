using Microsoft.AspNetCore.Mvc;

namespace MyBook.Controllers
{
    public class SubscriptionPayController : Controller
    {
        // GET
        public IActionResult SubscriptionPay()
        {
            return View();
        }
    }
}