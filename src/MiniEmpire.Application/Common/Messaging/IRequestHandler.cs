namespace MiniEmpire.Application.Common.Messaging;

/// <summary>Обробник одного типу запиту.</summary>
public interface IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}