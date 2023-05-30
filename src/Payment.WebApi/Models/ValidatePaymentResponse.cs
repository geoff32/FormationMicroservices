using System;
using Payment.Services.Models;

namespace Payment.WebApi.Models;

public record ValidatePaymentResponse(PaymentStatus Status)
{
    public ValidatePaymentResponse(Payment.Services.Models.Payment payment)
        : this(payment.Status)
    {
    }
}

