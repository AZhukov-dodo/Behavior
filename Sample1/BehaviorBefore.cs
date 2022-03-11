using MediatR;
using Microsoft.Extensions.Logging;

namespace Sample1;

public class BehaviorBefore<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<BehaviorBefore<TRequest, TResponse>> _logger;

    public BehaviorBefore(ILogger<BehaviorBefore<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        _logger.LogInformation("Behavior before raised");
        return await next();
    }
}