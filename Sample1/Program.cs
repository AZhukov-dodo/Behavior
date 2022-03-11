using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sample1;

/// <summary>
/// Пример 1.
/// События до хэндлера и события после хэндлера
/// </summary>
public static class Program
{
    public static async Task Main()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServiceCollection(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();


        var mediator = serviceProvider.GetService<IMediator>();

        await mediator.Send(new Request());
    }

    private static void ConfigureServiceCollection(IServiceCollection services)
    {
        services.AddLogging(_ => _.AddConsole()).Configure<LoggerFilterOptions>(_ => _.MinLevel = LogLevel.Information);
        services.AddMediatR(typeof(Program));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BehaviorBefore<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BehaviorAfter<,>));
    }
}