using Microsoft.AspNetCore.Mvc;

namespace MyBook.Controllers;

public class NewProductsController : Controller
{
    public IActionResult NewProducts()
    {
        return View();
    }
}