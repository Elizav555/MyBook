using MyBook.Entities;

namespace Repositories;

public interface IBookRepository
{
    public IQueryable<Book> GetAllBooks();
    public IQueryable<Book> GetFreeBooks();
}