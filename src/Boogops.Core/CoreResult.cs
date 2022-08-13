namespace Boogops.Core;

public class CoreResult
{
    private readonly List<CoreError> _errors = new();

    public bool Succeeded { get; private init; }

    public IEnumerable<CoreError> Errors => _errors;

    public static CoreResult Success { get; } = new() { Succeeded = true };

    public static CoreResult Failed(params CoreError[] errors)
    {
        var retval = new CoreResult { Succeeded = false };
        retval._errors.AddRange(errors);
        return retval;
    }

    public void Deconstruct(out bool succeeded)
    {
        succeeded = Succeeded;
    }
}