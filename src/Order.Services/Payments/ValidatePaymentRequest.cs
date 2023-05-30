using System;
namespace Order.Services.Payments;

public record ValidatePaymentRequest(Guid OrderId, double Amount);

