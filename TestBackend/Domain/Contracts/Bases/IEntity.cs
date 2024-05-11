namespace TestBackend.Domain.Contracts.Bases;

public interface IEntity<out TKey> : IEntity
{
    TKey Id { get; }
}

public interface IEntity
{ }