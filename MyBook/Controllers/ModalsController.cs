using Microsoft.AspNetCore.Mvc;
using MyBook.Models;

namespace MyBook.Controllers
{
    public class ModalsController : Controller
    {
        public IActionResult Delete(DeleteViewModel model)
        {
            return View(model);
        }
        public IActionResult Error(ModalsViewModel modalModel)
        {
            return View(modalModel);
        }
        public IActionResult Successful(ModalsViewModel modalModel)
        {
            return View(modalModel);
        }

        public IActionResult VkExists(ModalsViewModel modalModel)
        {
            return View(modalModel);
        }

        public IActionResult SubscrExists()
        {
            return View();
        }
    }
}
