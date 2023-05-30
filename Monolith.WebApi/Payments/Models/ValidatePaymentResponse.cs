using System;
using Payment.Services.Models;

namespace Monolith.WebApi.Payments.Models;

public record ValidatePaymentResponse(PaymentStatus Status)
{
    public ValidatePaymentResponse(Payment.Services.Models.Payment payment)
        : this(payment.Status)
    {
    }
}

