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

        public IEnumerable<UserSubscr>? GetExpiredUserSubscrs(string userId)
        {
            var subscrs = DbSet.Where(it => it.UserId == userId)
                .Include(it => it.Subscription).ToList();
            return subscrs.Where(it => DateTime.Parse(it.Subscription.EndDate).CompareTo(DateTime.Now) < 0);
        }

        public async Task DeleteExpiredUserSubscrs(string userId)
        {
            var subscrs = GetExpiredUserSubscrs(userId);
            if (subscrs != null && subscrs.Any())
                await RemoveAll(subscrs.ToList());
        }
    }
}
