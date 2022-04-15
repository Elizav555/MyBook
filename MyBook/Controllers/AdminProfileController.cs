﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.Models;
using MyBook.Models.Admin;
using Repositories;
using Type = MyBook.Entities.Type;
namespace MyBook.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
    public class AdminProfileController : Controller
    {
        private readonly IGenericRepository<Type> _typeRepository;
        private readonly EfAuthorRepository _authorRepository;
        private readonly EfBookRepository _bookRepository;
        private readonly UserManager<User> _userManager;

        public AdminProfileController(IGenericRepository<Type> typeRep,
        EfAuthorRepository authorRepository,
            EfBookRepository bookRepository,
            UserManager<User> userManager)
        {
            _typeRepository = typeRep;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditAuthor()
        {
            return PartialView("_EditAuthor", new EditAuthorViewModel { Authors = GetAuthors() });
        }

        public IActionResult EditBook()
        {
            return PartialView("_EditBook", new EditBookViewModel { Books = GetBooks() });
        }

        public IActionResult EditUser()
        {
            return PartialView("_EditUser", new EditUserViewModel { Users = GetUsers() });
        }

        public IActionResult EditBookCenter()
        {
            return PartialView("_EditBookCenter", new EditCenterViewModel { Centers = GetCenters() });
        }

        public IActionResult EditSubscription()
        {
            return PartialView("_EditSubscription", new EditSubscrViewModel { SubscrTypes = GetTypes() });
        }


        private List<Type> GetTypes()
        {
            return _typeRepository.Get().ToList();
        }

        private List<Author> GetAuthors()
        {
            return _authorRepository.GetAllAuthors().ToList();
        }

        private List<Book> GetBooks()
        {
            return _bookRepository.GetAllBooks().ToList();
        }

        private List<User> GetUsers()
        {
            return _userManager.Users.ToList();
        }

        private List<BookCenter> GetCenters()
        {
            return new List<BookCenter>();
        }
    }
}
