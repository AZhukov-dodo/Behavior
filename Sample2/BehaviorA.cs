using MediatR;
using Microsoft.Extensions.Logging;

namespace Sample2;

public class BehaviorA<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : RequestA, IRequest<TResponse>
{
    private readonly ILogger<BehaviorA<TRequest, TResponse>> _logger;

    public BehaviorA(ILogger<BehaviorA<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        _logger.LogInformation("Special behavior A raised BEFORE COMMON");
        return await  next();
    }
}