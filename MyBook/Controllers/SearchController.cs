using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using MyBook.Models;
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

    [HttpGet]
    [Route("[controller]/[action]")]
    public IActionResult SearchBooks(int page,string searchString)
    {
        if (page == 0) page = 1;
        if (!String.IsNullOrEmpty(searchString))
        {
            _vIewModel = new SearchViewModel(_bookRepository,searchString,page);
        }
        else
        {
            _vIewModel = new SearchViewModel(_bookRepository,"",page);
        }
        
        return View(_vIewModel);
    }
    
    [HttpGet]
    [Route("[controller]/[action]")]
    public IActionResult SearchAuthors(int page,string searchString)
    {
        if (page == 0) page = 1;
        if (!String.IsNullOrEmpty(searchString))
        {
            _vIewModel = new SearchViewModel(_authorRepository,searchString,page);
        }
        else
        {
            _vIewModel = new SearchViewModel(_authorRepository, "",page);
        }
        
        return View(_vIewModel);
    }

    public PartialViewResult SearchEditBooks(int page, string searchString)
    {
        if (page == 0) page = 1;
        _vIewModel = !String.IsNullOrEmpty(searchString) ? 
            new SearchViewModel(_bookRepository,searchString,page) : 
            new SearchViewModel(_bookRepository,"",page);
        return PartialView("../Partials/_EditBooksList", _vIewModel.Books.ToList());
    }

    public IActionResult SearchGenres()
    {
        throw new NotImplementedException();
    }
}