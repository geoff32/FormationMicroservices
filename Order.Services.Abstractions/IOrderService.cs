using System;
using OrderModels = Order.Services.Models;

namespace Order.Services.Abstractions;

public interface IOrderService
{
    Task<IEnumerable<OrderModels.Order>> GetOrders();

    Task<Guid> CreateOrderAsync(double amount);

    Task AcceptOrderAsync(Guid id);

    Task RefuseOrderAsync(Guid id);

    Task CancelOrderAsync(Guid id);
}

