using MediatR;
using Microsoft.Extensions.Logging;

namespace Sample2;

public class HandlerB : AsyncRequestHandler<RequestB>
{
    private readonly ILogger<HandlerB> _logger;

    public HandlerB(ILogger<HandlerB> logger)
    {
        _logger = logger;
    }

    protected override async Task Handle(RequestB request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handler B raised");
    }
}