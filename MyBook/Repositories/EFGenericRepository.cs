using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyBook.Entities;

namespace Repositories
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        MyBookContext _context;
        DbSet<TEntity> _dbSet;
        
        public EFGenericRepository(MyBookContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public async Task<TEntity> FindById(int id) => await _dbSet.FindAsync(id);

        public async Task Create(TEntity item)
        {
            _context.Entry(item).State = EntityState.Added;
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity item, List<string> excluded = null)
        {
            var entity = _context.Entry(item);
            entity.State = EntityState.Modified;

            if (excluded != null)
                foreach (var name in excluded)
                {
                    entity.Property(name).IsModified = false;
                }

            await _context.SaveChangesAsync();
        }

        public async Task Remove(TEntity item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveById(int id)
        {
            var entity = await FindById(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetWithInclude(
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties);
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.AsEnumerable().Where(predicate).ToList();
        }
        
        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        
        public IQueryable<TResult> GetWithMultiIncluding<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.Select(selector);
        }
    }
}