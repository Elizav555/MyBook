using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBook.Models;

namespace MyBook.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
    public class AdminProfileController : Controller
    {
        public IActionResult Index(string? partialName)
        {
            if (partialName == null)
                partialName = "_EditSubscription";
            return View(new AdminViewModel { PartialName = partialName });
        }

        public IActionResult EditAuthor()
        {
            var partialName = "_EditAuthor";
            return RedirectToAction("Index", new { partialName });
        }

        public IActionResult EditBook()
        {
            var partialName = "_EditBook";
            return RedirectToAction("Index", new { partialName });
        }

        public IActionResult EditUser()
        {
            var partialName = "_EditUser";
            return RedirectToAction("Index", new { partialName });
        }

        public IActionResult EditBookCenter()
        {
            var partialName = "_EditBookCenter";
            return RedirectToAction("Index", new { partialName });
        }

        public IActionResult EditSubscription()
        {
            var partialName = "_EditSubscription";
            return RedirectToAction("Index", new { partialName });
        }
    }
}
