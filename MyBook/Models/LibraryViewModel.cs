using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.Infrastructure.Services;
using Repositories;

namespace MyBook.ViewModels;

public class LibraryViewModel
{
    private readonly EfBookRepository _bookRepository;
    private readonly EFGenreRepository _genreRepository;
    private readonly IGenresFilterGetter _genresFilterGetter;
    private readonly ILanguageFilterGetter _languageFilterGetter;
    public List<Book> AllBooks { get; set; }
    public List<Author> AllAuthors { get; set; }
    public readonly string FilterLanguage;
    public readonly string FilterGenre;
    public List<SelectListItem> Languages = new List<SelectListItem>();
    public List<SelectListItem> Genres = new List<SelectListItem>();

    public LibraryViewModel(EfBookRepository _bookRepository, EFGenreRepository _genreRepository,
        EfAuthorRepository authorRepository, IGenresFilterGetter genresFilterGetter,
        ILanguageFilterGetter languageFilterGetter)
    {
        this._bookRepository = _bookRepository;
        this._genreRepository = _genreRepository;
        AllBooks = _bookRepository.GetAllBooks().ToList();
        AllAuthors = authorRepository.GetAllAuthors().ToList();
        _genresFilterGetter = genresFilterGetter;
        _languageFilterGetter = languageFilterGetter;
        Languages = _languageFilterGetter.GetItems(_bookRepository);
        Genres = _genresFilterGetter.GetItems(_genreRepository);
    }

    public LibraryViewModel(EfBookRepository _bookRepository, EFGenreRepository _genreRepository,
        EfAuthorRepository authorRepository, string filterLanguage, string filterGenre,
        IGenresFilterGetter genresFilterGetter, ILanguageFilterGetter languageFilterGetter)
    {
        this._bookRepository = _bookRepository;
        this._genreRepository = _genreRepository;
        _genresFilterGetter = genresFilterGetter;
        _languageFilterGetter = languageFilterGetter;
        FilterLanguage = filterLanguage;
        FilterGenre = filterGenre;
        AllBooks = _bookRepository.GetFilterBooksLanguageAndGenre(FilterLanguage, FilterGenre).ToList();
        AllAuthors = authorRepository.GetAllAuthors().ToList();
        Languages = _languageFilterGetter.GetItems(_bookRepository);
        Genres = _genresFilterGetter.GetItems(_genreRepository);
    }

    public LibraryViewModel(EfBookRepository _bookRepository, EFGenreRepository _genreRepository,
        EfAuthorRepository authorRepository, string filterLanguage, IGenresFilterGetter genresFilterGetter,
        ILanguageFilterGetter languageFilterGetter)
    {
        this._bookRepository = _bookRepository;
        this._genreRepository = _genreRepository;
        _genresFilterGetter = genresFilterGetter;
        _languageFilterGetter = languageFilterGetter;
        FilterLanguage = filterLanguage;
        AllBooks = _bookRepository.GetFilterBooksLanguage(FilterLanguage).ToList();
        AllAuthors = authorRepository.GetAllAuthors().ToList();
        Languages = _languageFilterGetter.GetItems(_bookRepository);
        Genres = _genresFilterGetter.GetItems(_genreRepository);
    }

    public LibraryViewModel(EfBookRepository _bookRepository, EFGenreRepository _genreRepository,
        EfAuthorRepository authorRepository, IGenresFilterGetter genresFilterGetter,
        ILanguageFilterGetter languageFilterGetter, string filterGenre)
    {
        this._bookRepository = _bookRepository;
        this._genreRepository = _genreRepository;
        _genresFilterGetter = genresFilterGetter;
        _languageFilterGetter = languageFilterGetter;
        FilterGenre = filterGenre;
        AllBooks = _bookRepository.GetFilterBooksGenre(FilterGenre).ToList();
        AllAuthors = authorRepository.GetAllAuthors().ToList();
        Languages = _languageFilterGetter.GetItems(_bookRepository);
        Genres = _genresFilterGetter.GetItems(_genreRepository);
    }
}