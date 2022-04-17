using Microsoft.AspNetCore.Mvc;
using MyBook.Infrastructure.Repositories;

namespace MyBook.Controllers;

public class NewProductsController : Controller
{
    private readonly EfBookRepository _bookRepository;

    public NewProductsController(EfBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public IActionResult NewProducts()
    {
        var view = _bookRepository.GetAllBooks();
        return View(view);
    }
}