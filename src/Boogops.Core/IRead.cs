namespace Boogops.Core;

public interface IRead<TAggregateRoot>
    where TAggregateRoot : IAggregateRoot
{
    Task<TAggregateRoot?> ReadAsync(uint id);
}