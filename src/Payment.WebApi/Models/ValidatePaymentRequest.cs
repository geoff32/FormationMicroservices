using System;
namespace Payment.WebApi.Models;

public record ValidatePaymentRequest(Guid OrderId, double Amount);

