using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.ViewModels;

namespace MyBook.Controllers;

public class SearchController : Controller
{
    private readonly EfBookRepository _bookRepository;
    private readonly EfAuthorRepository _authorRepository;
    private readonly EFUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private SearchViewModel _vIewModel;

    public SearchController(EfBookRepository bookRepository,
        EfAuthorRepository authorRepository,
        EFUserRepository userRepository,
        UserManager<User> userManager)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _userRepository = userRepository;
        _userManager = userManager;
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
        ViewData["searchBooks"] = searchString;
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
        ViewData["searchAuthors"] = searchString;
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
    
    public PartialViewResult SearchEditAuthors(int page, string searchString)
    {
        if (page == 0) page = 1;
        _vIewModel = !String.IsNullOrEmpty(searchString) ? 
            new SearchViewModel(_authorRepository,searchString,page) : 
            new SearchViewModel(_authorRepository,"",page);
        return PartialView("../Partials/_EditAuthorsList", _vIewModel.Authors.ToList());
    }
    public async Task<PartialViewResult> SearchEditUsers(int page, string searchString)
    {
        if (page == 0) page = 1;
        _vIewModel = !String.IsNullOrEmpty(searchString) ? 
            new SearchViewModel(_userRepository,searchString,page) : 
            new SearchViewModel(_userRepository,"",page);
        var admins = await _userManager.GetUsersForClaimAsync(new Claim(ClaimTypes.Role, "Admin"));
        _vIewModel.Users = _vIewModel.Users.Where(user => !admins.Contains(user));
        return PartialView("../Partials/_EditUsersList", _vIewModel.Users.ToList());
    }
}