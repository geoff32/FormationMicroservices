using System;
using Microsoft.Extensions.Logging;
using Payment.Services.Abstractions;
using Payment.Services.Models;
using PaymentModels = Payment.Services.Models;

namespace Payment.Services;

internal class PaymentService : IPaymentService
{
    private readonly PaymentDbContext _dbContext;
    private readonly ILogger<PaymentService> _logger;

    public PaymentService(PaymentDbContext dbContext, ILogger<PaymentService> logger)
    {
        _dbContext = dbContext;
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
        return payment;
    }
}

