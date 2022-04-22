using MyBook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
