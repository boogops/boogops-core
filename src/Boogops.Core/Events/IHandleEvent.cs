namespace Boogops.Core.Events;

public interface IHandleEvent
{
    public string Name { get; }
}

public interface IHandleEvent<in T> : IHandleEvent
    where T : IEvent
{
    Task<CoreResult> HandleAsync(T @event);
}