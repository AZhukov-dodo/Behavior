using MediatR;
using Microsoft.Extensions.Logging;

namespace Sample2;

public class CommonBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<CommonBehavior<TRequest, TResponse>> _logger;

    public CommonBehavior(ILogger<CommonBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        _logger.LogInformation("Common behavior raised");
        return await  next();
    }
}