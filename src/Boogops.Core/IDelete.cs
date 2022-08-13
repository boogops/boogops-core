namespace Boogops.Core;

public interface IDelete<in TAggregateRoot>
    where TAggregateRoot : IAggregateRoot
{
    Task DeleteAsync(TAggregateRoot entity);
}