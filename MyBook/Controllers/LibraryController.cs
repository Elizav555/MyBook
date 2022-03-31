using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.ViewModels;
using Repositories;

namespace MyBook.Controllers;

public class LibraryController: Controller
{
    private readonly IGenericRepository<Book> _bookRepository;
    private readonly IGenericRepository<Author> _authorRepository;
    private readonly IGenericRepository<Genre> _genreRepository;
    private readonly LibraryVIewModel _vIewModel;
    
    public LibraryController(
        IGenericRepository<Book> bookRepository,
        IGenericRepository<Author> authorRepository,
        IGenericRepository<Genre> genreRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _genreRepository = genreRepository;
        _vIewModel = new LibraryVIewModel(bookRepository,authorRepository,genreRepository);
    }

    public async Task<IActionResult> Index()
    {
        return View(_vIewModel);
    } 
    
    
}