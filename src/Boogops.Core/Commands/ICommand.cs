namespace Boogops.Core.Commands;

public interface ICommand
{
    Guid TraceId { get; set; }
}