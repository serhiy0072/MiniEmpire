using Microsoft.Extensions.DependencyInjection;

namespace MiniEmpire.Application.Common.Messaging;

public sealed class Mediator : ISender 
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>
    {
        var handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();
        var behaviors = _serviceProvider.GetServices<IPipelineBehavior<TRequest, TResponse>>();

        Func<Task<TResponse>> next = () => handler.Handle(request, cancellationToken);

        foreach(var behavior in Enumerable.Reverse(behaviors))
        {
            var inner = next;
        }


        return handler.Handle(request, cancellationToken);
    }
}
