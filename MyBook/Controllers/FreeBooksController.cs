using Microsoft.AspNetCore.Mvc;

namespace MyBook.Controllers;

public class FreeBooksController : Controller
{
    public IActionResult FreeBooks()
    {
        return View();
    }
}