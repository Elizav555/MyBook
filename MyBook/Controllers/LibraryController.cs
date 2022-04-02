using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.ViewModels;
using Repositories;

namespace MyBook.Controllers;

public class LibraryController: Controller
{
    private readonly LibraryVIewModel _vIewModel;
    
    public LibraryController(
        EfBookRepository bookRepository,
        EfAuthorRepository authorRepository)
    {
        _vIewModel = new LibraryVIewModel(bookRepository,authorRepository);
    }

    public async Task<IActionResult> Index()
    {
        return View(_vIewModel);
    } 
    
    
}