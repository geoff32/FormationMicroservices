using System;
namespace Payment.Services.Abstractions;
using PaymentModels = Payment.Services.Models;

public interface IPaymentService
{
    Task<PaymentModels.Payment> SubmitPaymentAsync(Guid orderId, double amount);
}

