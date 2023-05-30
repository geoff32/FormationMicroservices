using System;
namespace Payment.Services.Models;

public class Payment
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public double Amount { get; set; }
    public PaymentStatus Status { get; set; }
}