using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.Infrastructure.Services;
using MyBook.ViewModels;
using Repositories;

namespace MyBook.Controllers;

public class LibraryController : Controller
{
    private LibraryViewModel _viewModel;
    private readonly EfBookRepository _bookRepository;
    private readonly EFGenreRepository _genreRepository;
    private readonly EfAuthorRepository _authorRepository;
    private readonly IGenresFilterGetter _genresFilterGetter;
    private readonly ILanguageFilterGetter _languageFilterGetter;

    public LibraryController(EfBookRepository _bookRepository, EFGenreRepository _genreRepository,
        EfAuthorRepository _authorRepository, IGenresFilterGetter genresFilterGetter,
        ILanguageFilterGetter languageFilterGetter)
    {
        this._bookRepository = _bookRepository;
        this._genreRepository = _genreRepository;
        this._authorRepository = _authorRepository;
        _genresFilterGetter = genresFilterGetter;
        _languageFilterGetter = languageFilterGetter;
    }

    public async Task<IActionResult> Index(string filterLanguage, string filterGenre)
    {
        if ((String.IsNullOrEmpty(filterLanguage) || filterLanguage == "Все") && (String.IsNullOrEmpty(filterGenre) ||
        filterGenre == "Все"))
        {
            _viewModel = new LibraryViewModel(_bookRepository, _genreRepository, _authorRepository, _genresFilterGetter,
                _languageFilterGetter);
        }
        else
        if ((!String.IsNullOrEmpty(filterLanguage) || filterLanguage == "Все") && (!String.IsNullOrEmpty(filterGenre) ||
        filterGenre == "Все"))
        {
            _viewModel = new LibraryViewModel(_bookRepository, _genreRepository, _authorRepository, filterLanguage,
                filterGenre, _genresFilterGetter, _languageFilterGetter);
        }
        if ((String.IsNullOrEmpty(filterGenre) || filterGenre == "Все") && (!String.IsNullOrEmpty(filterLanguage)))
        {
            _viewModel = new LibraryViewModel(_bookRepository, _genreRepository, _authorRepository, filterLanguage,
                _genresFilterGetter, _languageFilterGetter);
        }
        
        if ((String.IsNullOrEmpty(filterLanguage) || filterLanguage == "Все") && (!String.IsNullOrEmpty(filterGenre)))
        {
            _viewModel = new LibraryViewModel(_bookRepository, _genreRepository, _authorRepository,
                _genresFilterGetter, _languageFilterGetter, filterGenre);
        }

        return View(_viewModel);
    }
}