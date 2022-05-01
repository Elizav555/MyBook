using MyBook.Entities;
using Microsoft.EntityFrameworkCore;
namespace MyBook.Infrastructure.Repositories
{
    public class EFHistoryRepository : EfGenericRepository<History>, IHistoryRepository
    {
        public EFHistoryRepository(MyBookContext context) : base(context)
        { }

        public IQueryable<History> GetHistories(string userId)
        {
            return DbSet.Where(x => x.UserId == userId)
                .Include(history => history.Book)
            .ThenInclude(book => book.Description);
        }
    }
}
