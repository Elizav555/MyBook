using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using Repositories;

namespace MyBook.Infrastructure.Repositories;

public class EfBookRepository : EfGenericRepository<Book>, IBookRepository
{
    public EfBookRepository(MyBookContext context) : base(context)
    { }

    public IQueryable<Book> GetAllBooks()
    {
        return DbSet
            .Include(book => book.AuthorBooks)
            .ThenInclude(book => book.Author)
            .Include(book => book.ImgLinks)
            .Include(book => book.Description);
    }

    public IQueryable<Book> GetFreeBooks()
    {
        return DbSet
            .Where(book => book.Description.Price == " ")
            .Include(book => book.AuthorBooks)
            .ThenInclude(book => book.Author)
            .Include(book => book.ImgLinks)
            .Include(book => book.Description);
    }

    public Book? GetBookWithImgLinks(int bookId)
    {
        return DbSet.
            Where(book => book.BookId == bookId)
            .Include(book => book.ImgLinks).FirstOrDefault();
    }

    public Book? GetFullBook(int bookId)
    {
        return DbSet
            .Where(book => book.BookId == bookId)
            .Include(book => book.Description)
            .Include(book => book.AuthorBooks)
            .ThenInclude(book => book.Author)
            .Include(book => book.BookGenres)
            .ThenInclude(book => book.Genre)
            .Include(book => book.ImgLinks)
            .FirstOrDefault();
    }
    
    public IQueryable<Book> GetFilterBooksLanguageAndGenre(string filterLanguage, string filterGenre)
    {
        return DbSet
            .Where(book => book.Language.Contains(filterLanguage) && book.BookGenres.First().Genre.Name.Contains(filterGenre))
            .Include(book => book.AuthorBooks)
            .ThenInclude(authorBook => authorBook.Author)
            .Include(book => book.ImgLinks)
            .Include(book => book.Description)
            .Include(book => book.BookGenres);
    }
    public IQueryable<Book> GetFilterBooksLanguage(string filterLanguage)
    {
        return DbSet
            .Where(book => book.Language.Contains(filterLanguage))
            .Include(book => book.AuthorBooks)
            .ThenInclude(authorBook => authorBook.Author)
            .Include(book => book.ImgLinks)
            .Include(book => book.Description)
            .Include(book => book.BookGenres);
    }
    public IQueryable<Book> GetFilterBooksGenre(string filterGenre)
    {
        return DbSet
            .Where(book => book.BookGenres.First().Genre.Name.Contains(filterGenre))
            .Include(book => book.AuthorBooks)
            .ThenInclude(authorBook => authorBook.Author)
            .Include(book => book.ImgLinks)
            .Include(book => book.Description)
            .Include(book => book.BookGenres);
    }
}