using Microsoft.AspNetCore.Mvc;
using MyBook.Infrastructure.Repositories;

namespace MyBook.Controllers
{
    public class AuthorController : Controller
    {
        private readonly EfAuthorRepository _authorRepository;

        public AuthorController(EfAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        
        [Route("Author/{authorId:int}")]
        public IActionResult Author(int authorId)
        {
            var resultAuthor = _authorRepository.GetFullAuthor(authorId);
            return View(resultAuthor);
        }
    }
}
