using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using MyBook.Models;
using MyBook.Infrastructure.Repositories;
using MyBook.Infrastructure.Services;
using Repositories;

namespace MyBook.Controllers;

public class FreeBooksController : Controller
{
    private FreeBooksViewModel _viewModel;
    private readonly EfBookRepository _bookRepository;
    private readonly EFGenreRepository _genreRepository;
    private readonly EfAuthorRepository _authorRepository;
    private readonly IGenresFilterGetter _genresFilterGetter;
    private readonly ILanguageFilterGetter _languageFilterGetter;

    public FreeBooksController(EfBookRepository _bookRepository, EFGenreRepository _genreRepository,
        EfAuthorRepository _authorRepository, IGenresFilterGetter genresFilterGetter,
        ILanguageFilterGetter languageFilterGetter)
    {
        this._bookRepository = _bookRepository;
        this._genreRepository = _genreRepository;
        this._authorRepository = _authorRepository;
        _genresFilterGetter = genresFilterGetter;
        _languageFilterGetter = languageFilterGetter;
    }
    
    [Route("[controller]/[action]/{pageCount:int?}")]
    public async Task<IActionResult> FreeBooks(string filterLanguage, string filterGenre)
    {
        if ((!String.IsNullOrEmpty(filterLanguage) || filterLanguage == "Все") && (!String.IsNullOrEmpty(filterGenre) ||
                filterGenre == "Все"))
        {
            _viewModel = new FreeBooksViewModel(_bookRepository, _genreRepository, _authorRepository, filterLanguage,
                filterGenre, _genresFilterGetter, _languageFilterGetter);
        }
        if ((String.IsNullOrEmpty(filterGenre) || filterGenre == "Все") && (!String.IsNullOrEmpty(filterLanguage)))
        {
            _viewModel = new FreeBooksViewModel(_bookRepository, _genreRepository, _authorRepository, filterLanguage,
                _genresFilterGetter, _languageFilterGetter);
        }
        
        if ((String.IsNullOrEmpty(filterLanguage) || filterLanguage == "Все") && (!String.IsNullOrEmpty(filterGenre)))
        {
            _viewModel = new FreeBooksViewModel(_bookRepository, _genreRepository, _authorRepository,
                _genresFilterGetter, _languageFilterGetter, filterGenre);
        }
        if ((String.IsNullOrEmpty(filterLanguage) || filterLanguage == "Все") && (String.IsNullOrEmpty(filterGenre) ||
                filterGenre == "Все"))
        {
            _viewModel = new FreeBooksViewModel(_bookRepository, _genreRepository, _authorRepository, _genresFilterGetter,
                _languageFilterGetter);
        }

        return View(_viewModel);
    }
    
}