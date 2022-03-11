using MediatR;
using Microsoft.Extensions.Logging;

namespace Sample2;

public class BehaviorB<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : RequestB, IRequest<TResponse>
{
    private readonly ILogger<BehaviorB<TRequest, TResponse>> _logger;

    public BehaviorB(ILogger<BehaviorB<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        _logger.LogInformation("Special behavior B raised AFTER COMMON");
        return await  next();
    }
}