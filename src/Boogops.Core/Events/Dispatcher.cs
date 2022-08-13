namespace Boogops.Core.Events;

public static class Dispatcher
{
    private static IList<object>? _handlers;

    public static void Register(object handler)
    {
        _handlers ??= new List<object>();
        _handlers.Add(handler);
    }

    public static async Task<CoreResult> RaiseAsync<T>(T @event)
        where T : IEvent
    {
        if (_handlers == null)
        {
            return CoreResult.Success;
        }

        var retval = CoreResult.Success;

        try
        {
            var handlers = _handlers.OfType<IHandleEvent<T>>();
            var coreResults = await Task.WhenAll(
                handlers.Select(he => he.HandleAsync(@event)));
            var coreErrors = coreResults.Where(cr => cr.Succeeded == false)
                .SelectMany(cr => cr.Errors);

            if (coreErrors.Any())
            {
                retval = CoreResult.Failed(coreErrors.ToArray());
            }
        }
        catch (Exception e)
        {
            retval = CoreResult.Failed(new CoreError { Message = e.Message });
        }

        return retval;
    }
}