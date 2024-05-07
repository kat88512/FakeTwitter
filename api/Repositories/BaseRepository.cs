using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public abstract class BaseRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
        where TId : struct
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public virtual async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public virtual void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
