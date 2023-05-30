using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Payment.Services;
using Payment.Services.Abstractions;
using Payment.Services.Models;

namespace Microsoft.Extensions.DependencyInjection;

public static class PaymentExtensions
{
    private const string PROGRAMNAME = Infrastructure.Common.Constants.Queues.PAYMENT;

    public static void AddPaymentServices(this IServiceCollection services)
    {
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddDatabase<PaymentDbContext>(PROGRAMNAME);
    }
}

