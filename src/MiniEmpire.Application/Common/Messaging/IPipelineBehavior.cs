namespace MiniEmpire.Application.Common.Messaging;

/// <summary>Обгортка навколо обробника: робить щось до і після, або зупиняє ланцюжок.</summary>
public interface IPipelineBehavior<TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request, Func<Task<TResponse>> next, CancellationToken cancellationToken);
}
