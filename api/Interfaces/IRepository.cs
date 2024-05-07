namespace api.Interfaces
{
    public interface IRepository<TEntity, TId>
        where TEntity : IAggregateRoot<TId>
        where TId : struct
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity?> GetByIdAsync(TId id);
        void Update(TEntity entity);
    }
}
