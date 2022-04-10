using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using Repositories;

namespace MyBook.Controllers;

public class GenreCardController: Controller
{
    private readonly IGenericRepository<Book> _bookRepository;

    public GenreCardController(IGenericRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public IActionResult GenreCard()
    {
        var freeBooks =  _bookRepository.GetWithMultiIncluding(
            book => book,
            book => book.Description.Price == " ",
            books => 
                books.Include(book=>book.Description)
                    .Include(book => book.AuthorBooks)
                    .ThenInclude(authorBook =>  authorBook.Author)
                    .Include(book => book.ImgLinks));
        
        return View(freeBooks);
    }
}