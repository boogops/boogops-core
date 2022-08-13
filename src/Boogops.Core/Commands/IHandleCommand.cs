namespace Boogops.Core.Commands;

public interface IHandleCommand
{
    string Name { get; }
}

public interface IHandleCommand<in T> : IHandleCommand
    where T : ICommand
{
    Task<CoreResult> HandleAsync(T command);
}