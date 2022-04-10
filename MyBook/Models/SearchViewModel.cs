using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using Repositories;

namespace MyBook.ViewModels;

public class SearchViewModel
{
    private readonly IGenericRepository<Book>? _bookRepository;
    private readonly IGenericRepository<Author>? _authorRepository;
    public readonly string SearchString;
    public List<Book> Books { get; set; } = new();
    public List<Author> Authors { get; set; } = new();

    public SearchViewModel(
        IGenericRepository<Book> bookRepository,
        IGenericRepository<Author> authorRepository,
        string searchString)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        SearchString = searchString;

        Books = GetSearchBooks()!;
        Authors = GetSearchAuthors()!;
    }
    
    public SearchViewModel(
        IGenericRepository<Author> authorRepository,
        string searchString)
    {
        _authorRepository = authorRepository;
        SearchString = searchString;

        Authors = GetSearchAuthors()!;
    }
    
    public SearchViewModel(
        IGenericRepository<Book> bookRepository,
        string searchString)
    {
        _bookRepository = bookRepository;
        SearchString = searchString;

        Books = GetSearchBooks()!;
    }

    private List<Book>? GetSearchBooks()
    {
        return _bookRepository?.GetWithMultiIncluding(
            book => book,
            book => book.Name.Contains(SearchString),
            books => 
                books.Include(book => book.AuthorBooks)
                    .ThenInclude(authorBook =>  authorBook.Author)
                    .Include(book => book.ImgLinks)
                    .Include(book=>book.Description)
        ).ToList();
    }
    
    private List<Author>? GetSearchAuthors()
    {
        return _authorRepository?.GetWithMultiIncluding(
            author => author,
            author => author.Name.Contains(SearchString),
            authors => 
                authors.Include(author => author.AuthorBooks)
                    .ThenInclude(authorBook =>  authorBook.Book)
                    .Include(author => author.ImgLinks)
        ).ToList();
    }
}