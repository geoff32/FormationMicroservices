using System;
using Events.Common;
using MassTransit;
using Microsoft.Extensions.Logging;
using Payment.Services.Abstractions;
using PaymentModels = Payment.Services.Models;

namespace Payment.Services;

internal class PaymentService : IPaymentService
{
    private readonly PaymentDbContext _dbContext;
    private readonly IBus _bus;
    private readonly ILogger<PaymentService> _logger;

    public PaymentService(PaymentDbContext dbContext, IBus bus, ILogger<PaymentService> logger)
    {
        _dbContext = dbContext;
        this._bus = bus;
        _logger = logger;
    }

    public async Task<PaymentModels.Payment> SubmitPaymentAsync(Guid orderId, double amount)
    {
        var payment = new PaymentModels.Payment
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            Amount = amount,
            Status = amount > 1000 ? PaymentModels.PaymentStatus.Refused : PaymentModels.PaymentStatus.Accepted
        };

        _dbContext.Payments.Add(payment);

        await _dbContext.SaveChangesAsync();

        if (payment.Status == PaymentModels.PaymentStatus.Accepted)
        {

            try
            {
                await _bus.Publish(new AcceptOrderEvent(payment.OrderId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unable to publish {typeof(AcceptOrderEvent)}");
            }
        }
        return payment;
    }
}

