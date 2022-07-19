using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly CoreContext _context;
        public GeneralRepository(CoreContext context)
        {
            _context = context;
        }
        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            return _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        }
        
        public Task<List<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> expression, int skip = 0, int take = 0, string orderProperty = null, string direct = null, params string[] includes) where TEntity : class
        {
            var query = Include(_context.Set<TEntity>(), includes);
            if (orderProperty != null)
                query = direct == null || direct == "Asc" ? query.OrderBy(x => EF.Property<object>(x, orderProperty)) : query.OrderByDescending(x => EF.Property<object>(x, orderProperty));
            query = query.Where(expression).Skip(skip);
            if (take > 0)
                query = query.Take(take);

            return query.ToListAsync();
        }
        
        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        protected IQueryable<T> Include<T>(IQueryable<T> query, params string[] includes) where T : class
        {
            if (includes != null && includes.Any())
            {
                foreach (var property in includes)
                {
                    query = query.Include(property);
                }
            }
            return query;
        }
    }
}
