using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.ViewModels;
using Repositories;

namespace MyBook.Controllers
{

    public class LibraryController : Controller
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IGenericRepository<Author> _authorRepository;
        private readonly IGenericRepository<Genre> _genreRepository;
        private LibraryVIewModel _vIewModel;

        public LibraryController(IGenericRepository<Book> bookRepository,
            IGenericRepository<Author> authorRepository,
            IGenericRepository<Genre> genreRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
        }

        public async Task<IActionResult> Index(string searchString)
        {

            if (String.IsNullOrEmpty(searchString) || searchString=="Все")
            {
                _vIewModel = new LibraryVIewModel(_bookRepository, _authorRepository, _genreRepository);
            }
            else
            {
                _vIewModel = new LibraryVIewModel(_bookRepository, _authorRepository,
                    _genreRepository, searchString);
            }

            return View(_vIewModel);
        }
    }
}