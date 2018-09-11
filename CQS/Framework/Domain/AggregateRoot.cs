namespace CQS.Framework.Domain
{
    public interface IAggregateRoot
    {
    }

    public interface IAggregateRoot<out TId> : IAggregateRoot
    {
        TId Id { get; }
    }
}