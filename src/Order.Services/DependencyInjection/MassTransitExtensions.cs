using MassTransit;
using Order.Services.Consumers;

namespace Microsoft.Extensions.DependencyInjection;

public static class MassTransitExtensions
{
    public static void AddMassTransitOrder(this IServiceCollection services)
    {
        services.AddMassTransit(cfg =>
        {
            cfg.AddConsumersFromNamespaceContaining<AcceptOrderEventConsumer>();
            cfg.UsingRabbitMq(ConfigureRabbitMq);
        });
    }

    private static void ConfigureRabbitMq(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
    {
        configurator.Host("localhost", "/", cfg =>
        {
            cfg.Username("guest");
            cfg.Password("guest");
        });

        configurator.ConfigureEndpoints(context);
    }
}
