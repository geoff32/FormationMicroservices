using System;
namespace Monolith.WebApi.Payments.Models;

public record ValidatePaymentRequest(Guid OrderId, double Amount);

