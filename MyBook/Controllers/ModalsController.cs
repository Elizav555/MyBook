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
