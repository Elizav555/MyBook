using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;

namespace MyBook.Infrastructure.Repositories;

public class EfAuthorRepository: EfGenericRepository<Author>,IAuthorRepository
{
    public EfAuthorRepository(MyBookContext context) : base(context)
    { }

    public IQueryable<Author> GetAllAuthors()
    {
        return DbSet
            .Include(author => author.AuthorBooks)
            .ThenInclude(authorBook => authorBook.Book)
            .Include(author => author.ImgLinks);
    }

}

