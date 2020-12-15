using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OamCake.Repository
{
    public class Repository<TEntity>  : IRepository<TEntity>
        where TEntity : class, new()
    {
        private readonly DbContext _context;

        public Repository(DbContext context) => _context = context;

        public void Create(Func<TEntity, TEntity> entityFactory)
        {
            _context.Set<TEntity>().Add(entityFactory(new TEntity()));
        }

        public async Task<bool> Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(Func<TEntity, TEntity> entityFactory, Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (entity != null)
            {
                _context.Set<TEntity>().Update(entityFactory(entity));
                return true;
            }
            return false;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task SaveChangesAsync() =>  await _context.SaveChangesAsync();
    }
}
