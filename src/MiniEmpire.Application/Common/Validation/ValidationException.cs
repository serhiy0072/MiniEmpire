namespace MiniEmpire.Application.Common.Validation;

public sealed class ValidationException : Exception
{
    public IReadOnlyList<string> Errors { get; }

    public ValidationException(IEnumerable<string> errors) : base("Validation failed.")
    {
        Errors = errors.ToList().AsReadOnly();
    }
}
