using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IGenericRepository<TEntity>  where TEntity : class 
    {
        Task Create(TEntity item);
        Task<TEntity> FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        Task Remove(TEntity item);
        Task RemoveById(int id);
        Task Update(TEntity item,List<string> excluded);
    }
}