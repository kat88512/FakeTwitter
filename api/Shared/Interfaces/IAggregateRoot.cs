namespace Api.Shared.Interfaces
{
    public interface IAggregateRoot<TId>
        where TId : struct
    {
        TId Id { get; }
    }
}
