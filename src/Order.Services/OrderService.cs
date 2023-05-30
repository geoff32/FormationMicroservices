using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Order.Services.Abstractions;
using Order.Services.Exceptions;
using Order.Services.Models;
using Order.Services.Payments;
using OrderModels = Order.Services.Models;

namespace Order.Services;

internal class OrderService : IOrderService
{
    private readonly OrderDbContext _dbContext;
    private readonly IPaymentApi _paymentApi;
    private readonly ILogger<OrderService> _logger;

    public OrderService(OrderDbContext dbContext, IPaymentApi paymentApi, ILogger<OrderService> logger)
    {
        _dbContext = dbContext;
        _paymentApi = paymentApi;
        _logger = logger;
    }

    public async Task<Guid> CreateOrderAsync(double amount)
    {
        var order = new OrderModels.Order
        {
            Id = Guid.NewGuid(),
            Amount = amount,
            Status = OrderStatus.Created
        };

        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();

        var payment = await _paymentApi.ValidateAsync(new(order.Id, order.Amount));
        if (payment.Status == PaymentApiStatus.Accepted)
        {
            await AcceptOrderAsync(order.Id);
        }
        else
        {
            await RefuseOrderAsync(order.Id);
        }

        return order.Id;
    }

    public Task AcceptOrderAsync(Guid id) =>
        ChangeOrderStatusAsync(id, OrderStatus.Accepted);

    public Task RefuseOrderAsync(Guid id) =>
        ChangeOrderStatusAsync(id, OrderStatus.Refused);

    public Task CancelOrderAsync(Guid id) =>
        ChangeOrderStatusAsync(id, OrderStatus.Cancelled);

    private async Task ChangeOrderStatusAsync(Guid id, OrderStatus status)
    {
        var order = await _dbContext.Orders.FindAsync(id);

        if (order == null)
        {
            throw new OrderNotFoundException(id);
        }

        order.Status = status;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrderModels.Order>> GetOrders()
        => await _dbContext.Orders.AsNoTracking().ToArrayAsync();
}

