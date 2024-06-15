namespace api.Shared.Interfaces
{
    public interface IRepository<TEntity, TId>
        where TEntity : IAggregateRoot<TId>
        where TId : struct
    {
        Task AddAsync(TEntity entity);
        Task<bool> CheckIfExistsAsync(TId id);
        Task DeleteAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(TId id);
        Task UpdateAsync(TEntity entity);
    }
}
