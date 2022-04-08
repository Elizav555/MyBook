using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;

namespace MyBook.Controllers
{
    public class BookController : Controller
    {
        private readonly EfBookRepository _bookRepository;

        public BookController(EfBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        // GET
        [Route("Book/{bookId:int}")]
        public IActionResult Book(int bookId)
        {
            var resultBook = _bookRepository.GetFullBook(bookId);
            return View(resultBook);
        }
    }
}