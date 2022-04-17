using MyBook.Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBook.Infrastructure.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public User GetUserWithSubscr(string userId);
    }
}
