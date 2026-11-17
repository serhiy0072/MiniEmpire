using MiniEmpire.Application.Common.Messaging;
using MiniEmpire.Application.Common.Validation;

namespace MiniEmpire.Application.Common.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, Func<Task<TResponse>> next, CancellationToken cancellationToken)
    {
        var errors = new List<string>();
        foreach (var validator in _validators)
        {
            errors.AddRange(validator.Validate(request));
        }

        if (errors.Count>0) 
            throw new ValidationException(errors);

        return next();
    }
}
