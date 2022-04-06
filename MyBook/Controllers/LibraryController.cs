using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.ViewModels;
using Repositories;

namespace MyBook.Controllers;

public class LibraryController: Controller
{
    private readonly LibraryViewModel _viewModel;
    
    public LibraryController(
        EfBookRepository bookRepository,
        EfAuthorRepository authorRepository)
    {
        _viewModel = new LibraryViewModel(bookRepository,authorRepository);
    }

    public async Task<IActionResult> Index()
    {
        return View(_viewModel);
    } 
    
    
}