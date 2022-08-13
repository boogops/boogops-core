namespace Boogops.Core;

public interface ICreate<TAggregateRoot>
    where TAggregateRoot : IAggregateRoot
{
    Task<TAggregateRoot> CreateAsync(TAggregateRoot entity);
}