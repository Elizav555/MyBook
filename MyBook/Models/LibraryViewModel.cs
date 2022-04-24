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
    private readonly IGenericRepository<Genre> genreRepository;
    public IQueryable<Book> AllBooks { get; set; }
    public IQueryable<Author> AllAuthors { get; set; }

    private readonly EFGenreRepository _genreRepository;
    private readonly IGenresFilterGetter _genresFilterGetter;
    private readonly ILanguageFilterGetter _languageFilterGetter;
    public readonly string FilterLanguage;
    public readonly string FilterGenre;
    public List<SelectListItem> Languages = new List<SelectListItem>();
    public List<SelectListItem> Genres = new List<SelectListItem>();

    public LibraryViewModel(EfBookRepository _bookRepository, EFGenreRepository _genreRepository,
        EfAuthorRepository authorRepository, IGenresFilterGetter genresFilterGetter,
        ILanguageFilterGetter languageFilterGetter)
    {
        this._bookRepository = _bookRepository;
        AllBooks = _bookRepository.GetAllBooks();
        AllAuthors = authorRepository.GetAllAuthors();
        Languages = GetLanguages();
        Genres = GetGenres();
        this._genreRepository = _genreRepository;
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
        AllBooks = _bookRepository.GetFilterBooksLanguageAndGenre(FilterLanguage, FilterGenre);
        AllAuthors = authorRepository.GetAllAuthors();
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
        AllBooks = _bookRepository.GetFilterBooksLanguage(FilterLanguage);
        AllAuthors = authorRepository.GetAllAuthors();
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
        AllBooks = GetFilterBooks();
        AllAuthors = authorRepository.GetAllAuthors();
        Languages = GetLanguages();
        Genres = GetGenres();
    }

    public IQueryable<Book> GetFilterBooks()
    {
        return _bookRepository.GetFilterBooks(FilterLanguage, FilterGenre);
    }

    private List<SelectListItem> GetLanguages()
    {
        List<Book> allBooks = _bookRepository.GetAllBooks().ToList();
        Languages.Add(new SelectListItem() {Text = "Все", Value = "Все"});
        List<string> languages = new List<string>();
        foreach (var book in allBooks)
        {
            if (!languages.Contains(book.Language))
            {
                languages.Add(book.Language);
            }
        }

        foreach (var lang in languages)
        {
            var display = "";
            switch (lang)
            {
                case "ru":
                    display = "русский";
                    break;
                case "en":
                    display = "английский";
                    break;
                case "de":
                    display = "немецкий";
                    break;
                case "it":
                    display = "итальянский";
                    break;
                default:
                    display = lang;
                    break;
            }
            var item = new SelectListItem() {Text = $"{display}", Value = $"{lang}"};
            Languages.Add(item);
        }

        return Languages;
    }

    private List<SelectListItem> GetGenres()
    {
        List<Genre> allGenres = genreRepository.Get().ToList();
        Genres.Add(new SelectListItem() {Text = "Все", Value = "Все"});
        foreach (var genre in allGenres)
        {
            var genreName = genre.Name;
            var item = new SelectListItem() {Text = $"{genreName}", Value = $"{genreName}"};
            Genres.Add(item);
        }

        return Genres;
    }
}