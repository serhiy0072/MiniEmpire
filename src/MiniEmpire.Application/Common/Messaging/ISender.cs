namespace MiniEmpire.Application.Common.Messaging;

/// <summary>Точка входу: відправляє запит крізь pipeline до обробника.</summary>
public interface ISender
{
    Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest<TResponse>;
}
