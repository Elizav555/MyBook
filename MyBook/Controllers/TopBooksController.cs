using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using Repositories;

namespace MyBook.Controllers;

public class TopBooksController : Controller
{
    private readonly EfBookRepository _bookRepository;

    public TopBooksController(EfBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    [Route("[controller]")]
    public IActionResult Index()
    {
        var books = _bookRepository.GetTopBooks().ToList();
        return View(books);
    }
}