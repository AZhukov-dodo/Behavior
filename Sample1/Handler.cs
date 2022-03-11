using MediatR;
using Microsoft.Extensions.Logging;

namespace Sample1;

public class Handler : AsyncRequestHandler<Request>
{
    private readonly ILogger<Handler> _logger;

    public Handler(ILogger<Handler> logger)
    {
        _logger = logger;
    }

    protected override async Task Handle(Request request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handler raised");
    }
}