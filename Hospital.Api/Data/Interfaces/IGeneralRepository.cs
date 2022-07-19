using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public interface IGeneralRepository
    {
        Task<List<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> expression, int skip = 0, int take = 0, string orderProperty = null, string direct = null, params string[] includes) where TEntity : class;
        Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
    }
}
