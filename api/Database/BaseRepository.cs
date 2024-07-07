using api.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Database
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

        public virtual async Task AddAsync(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<bool> CheckIfExistsAsync(TId id)
        {
            return await _dbSet.AnyAsync(e => e.Id.Equals(id));
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
