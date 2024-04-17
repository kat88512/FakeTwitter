namespace api.Interfaces
{
    public interface IRepository<TEntity, TId>
        where TEntity : IAggregateRoot
        where TId : struct
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TId id);
        Task UpdateAsync(TEntity entity);
    }
}
