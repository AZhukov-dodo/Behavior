using MediatR;
using Microsoft.Extensions.Logging;

namespace Sample1;

public class BehaviorAfter<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<BehaviorAfter<TRequest, TResponse>> _logger;

    public BehaviorAfter(ILogger<BehaviorAfter<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var response = await next();
        _logger.LogInformation("Behavior after raised");
        return response;
    }
}