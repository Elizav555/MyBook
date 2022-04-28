using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBook.Infrastructure.Repositories
{
    public class EFUserSubscrRepository : EfGenericRepository<UserSubscr>, IUserSubscrRepository
    {
        public EFUserSubscrRepository(MyBookContext context) : base(context)
        { }

        public UserSubscr? GetUserSubscr(string userId, int subscrId)
        {
            return DbSet.Where(it => it.UserId == userId && it.SubscriptionId == subscrId)
                .Include(it => it.Subscription)
                .Include(it => it.User)
                .FirstOrDefault();
        }
    }
}
