using System;
namespace Order.Services.Models;

public class Order
{
    public Guid Id { get; set; }
    public double Amount { get; set; }
    public OrderStatus Status { get; set; }
}