using Microsoft.AspNetCore.Mvc;

namespace MyBook.Controllers;

public class FreeBooksController : Controller
{
    [Route("[controller]/[action]/{pageCount:int?}")]
    public IActionResult FreeBooks(int? pageCount)
    {
        pageCount ??= 1;
        return View();
    }
}