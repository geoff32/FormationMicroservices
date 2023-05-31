using Order.Services;
using Order.Services.Abstractions;

namespace Microsoft.Extensions.DependencyInjection;

public static class OrderExtensions
{
    private const string PROGRAMNAME = Infrastructure.Common.Constants.Queues.ORDER;

    public static void AddOrderServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        services.AddDatabase<OrderDbContext>(PROGRAMNAME);
        services.AddMassTransitOrder();

    }
}

