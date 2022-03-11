using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sample2;

/// <summary>
/// Пример 2.
/// Разное поведение для разных хэндлеров
/// </summary>
public class Program
{
    public static async Task Main()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServiceCollection(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();


        var mediator = serviceProvider.GetService<IMediator>();
        var logger = serviceProvider.GetService<ILogger<Program>>();

        await mediator.Send(new RequestA());
        logger.LogInformation("----------");
        await mediator.Send(new RequestB());
    }

    private static void ConfigureServiceCollection(IServiceCollection services)
    {
        services.AddLogging(_ => _.AddConsole()).Configure<LoggerFilterOptions>(_ => _.MinLevel = LogLevel.Information);
        services.AddMediatR(typeof(Program));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BehaviorA<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommonBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BehaviorB<,>));
    }
}