using Order.Services;
using Order.Services.Abstractions;
using Order.Services.Payments;
using Polly;
using Polly.Extensions.Http;
using Refit;

namespace Microsoft.Extensions.DependencyInjection;

public static class OrderExtensions
{
    private const string PROGRAMNAME = Infrastructure.Common.Constants.Queues.ORDER;

    public static void AddOrderServices(this IServiceCollection services)
    {
        var paymentApiPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(3, retryCount => TimeSpan.FromSeconds(retryCount));

        services.AddScoped<IOrderService, OrderService>();
        services.AddDatabase<OrderDbContext>(PROGRAMNAME);

        services.AddRefitClient<IPaymentApi>()
            .ConfigureHttpClient(httpClient =>
                httpClient.BaseAddress = new Uri("https://localhost:7277"))
            .AddPolicyHandler(paymentApiPolicy);

    }
}

