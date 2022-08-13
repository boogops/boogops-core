namespace Boogops.Core;

public interface IUpdate<in TAggregateRoot>
{
    Task UpdateAsync(TAggregateRoot entity);
}