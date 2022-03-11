using MediatR;
using Microsoft.Extensions.Logging;

namespace Sample2;

public class HandlerA : AsyncRequestHandler<RequestA>
{
    private readonly ILogger<HandlerA> _logger;

    public HandlerA(ILogger<HandlerA> logger)
    {
        _logger = logger;
    }

    protected override async Task Handle(RequestA request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handler A raised");
    }
}