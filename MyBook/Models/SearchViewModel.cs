using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.Models;
using Validator = MyBook.Core.Validation.Validator;

namespace MyBook.ViewModels;

public class SearchViewModel
{
    public PageViewModel PageViewModel { get; set; }
    private readonly EfBookRepository _bookRepository;
    private readonly EfAuthorRepository _authorRepository;
    private readonly EFUserRepository _userRepository;
    [RegularExpression(Validator.LettersValidationString,ErrorMessage = "Только буквы")]
    public readonly string SearchString;
    public IQueryable<Book> Books { get; set; }
    public IQueryable<Author> Authors { get; set; }
    public IQueryable<User> Users { get; set; }

    public SearchViewModel(
        EfBookRepository bookRepository,
        EfAuthorRepository authorRepository,
        string searchString)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        SearchString = searchString;
        
        Books = GetSearchBooks()!;
        Authors = GetSearchAuthors()!;
    }
    
    public SearchViewModel(
        EfAuthorRepository authorRepository,
        string searchString,
        int pageNumber)
    {
        _authorRepository = authorRepository;
        SearchString = searchString;
        var allAuthors = GetSearchAuthors()!;
        Authors = allAuthors.Take(pageNumber*10);
        PageViewModel = new PageViewModel(Authors.Count(), pageNumber);
    }
    public SearchViewModel(
        EFUserRepository userRepository,
        string searchString,
        int pageNumber)
    {
        _userRepository = userRepository;
        SearchString = searchString;
        var allUsers = GetSearchUsers()!;
        Users = allUsers.Take(pageNumber*10);
        PageViewModel = new PageViewModel(Users.Count(), pageNumber);
    }
    
    public SearchViewModel(
        EfBookRepository bookRepository,
        string searchString,
        int pageNumber)
    {
        _bookRepository = bookRepository;
        SearchString = searchString;
        var searchBooks = GetSearchBooks()!;
        Books = searchBooks.Take(pageNumber*10);
        PageViewModel = new PageViewModel(Books.Count(), pageNumber);
    }
    
    private IQueryable<Book>? GetSearchBooks()
    {
        return _bookRepository.GetSearchBooks(SearchString);
    }
    
    private IQueryable<Author>? GetSearchAuthors()
    {
        return _authorRepository.GetSearchAuthors(SearchString);
    }
    
    private IQueryable<User>? GetSearchUsers()
    {
        return _userRepository?.GetUsersWithName(SearchString);
    }
}