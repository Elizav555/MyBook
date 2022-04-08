using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using MyBook.ViewModels;
using Repositories;

namespace MyBook.Controllers;

public class SearchController : Controller
{
    private readonly IGenericRepository<Book> _bookRepository;
    private readonly IGenericRepository<Author> _authorRepository;
    private SearchViewModel _vIewModel;

    public SearchController(IGenericRepository<Book> bookRepository,
        IGenericRepository<Author> authorRepository,
        IGenericRepository<Genre> genreRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }
    public async Task<IActionResult> SearchAll(string searchString)
    {
        if (!String.IsNullOrEmpty(searchString))
        {
            _vIewModel = new SearchViewModel(_bookRepository,_authorRepository,searchString);
        }
        else
        {
            _vIewModel = new SearchViewModel(_bookRepository, _authorRepository, "");
        }

        return View(_vIewModel);
    }

    public IActionResult SearchBooks(string searchString)
    {
        if (!String.IsNullOrEmpty(searchString))
        {
            _vIewModel = new SearchViewModel(_bookRepository,searchString);
        }
        else
        {
            _vIewModel = new SearchViewModel(_bookRepository, "");
        }
        
        return View(_vIewModel);
    }

    public IActionResult SearchAuthors(string searchString)
    {
        if (!String.IsNullOrEmpty(searchString))
        {
            _vIewModel = new SearchViewModel(_authorRepository,searchString);
        }
        else
        {
            _vIewModel = new SearchViewModel(_authorRepository, "");
        }
        
        return View(_vIewModel);
    }

    public IActionResult SearchGenres()
    {
        throw new NotImplementedException();
    }
}