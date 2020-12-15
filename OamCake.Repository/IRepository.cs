using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OamCake.Repository
{
    public interface IRepository<TEntity>
    {
        void Create(Func<TEntity, TEntity> entityFactory);

        Task<bool> Delete(Expression<Func<TEntity, bool>> predicate);

        Task<bool> Update(Func<TEntity, TEntity> entityFactory, Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> predicate);

        Task SaveChangesAsync();
    }
}
