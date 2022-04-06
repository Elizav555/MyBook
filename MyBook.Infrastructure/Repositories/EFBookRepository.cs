using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using Repositories;

namespace MyBook.Infrastructure.Repositories;

public class EfBookRepository: EfGenericRepository<Book>,IBookRepository
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
}