using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using Repositories;

namespace MyBook.ViewModels;

public class LibraryViewModel
{
    private readonly EfBookRepository _bookRepository;
    private readonly IGenericRepository<Book> bookRepository;
    private readonly IGenericRepository<Genre> genreRepository;
    public List<Book> AllBooks { get; set; }
    public List<Author> AllAuthors { get; set; }

    public readonly string FilterLanguage;
    public readonly string FilterGenre;

    public List<SelectListItem> Languages = new List<SelectListItem>();
    public List<SelectListItem> Genres = new List<SelectListItem>();

    public LibraryViewModel(
        EfBookRepository _bookRepository,
        EfAuthorRepository authorRepository, IGenericRepository<Book> bookRepository,
        IGenericRepository<Genre> genreRepository)
    {
        this._bookRepository = _bookRepository;
        this.genreRepository = genreRepository;
        AllBooks = _bookRepository.GetAllBooks().ToList();
        AllAuthors = authorRepository.GetAllAuthors().ToList();
        this.bookRepository = bookRepository;
        Languages = GetLanguages();
        Genres = GetGenres();
    }

    public LibraryViewModel(
        EfBookRepository _bookRepository,
        EfAuthorRepository authorRepository, IGenericRepository<Book> bookRepository, string filterLanguage,
        IGenericRepository<Genre> genreRepository, string filterGenre)
    {
        this._bookRepository = _bookRepository;
        this.bookRepository = bookRepository;
        this.genreRepository = genreRepository;
        FilterLanguage = filterLanguage;
        FilterGenre = filterGenre;
        AllBooks = GetFilterBooks().ToList();
        AllAuthors = authorRepository.GetAllAuthors().ToList();
        Languages = GetLanguages();
        Genres = GetGenres();
    }

    public List<Book> GetFilterBooks()
    {
        return _bookRepository.GetFilterBooks(FilterLanguage, FilterGenre).ToList();
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