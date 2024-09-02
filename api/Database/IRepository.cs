using Api.Shared.Interfaces;

namespace Api.Database
{
    public interface IRepository<TEntity, TId>
        where TEntity : IAggregateRoot<TId>
        where TId : struct
    {
        Task<bool> CheckIfExistsAsync(TId id);
        Task<TEntity?> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
