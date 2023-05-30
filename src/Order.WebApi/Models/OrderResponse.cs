using Order.Services.Models;

namespace Order.WebApi.Models;

public record OrderResponse(Guid Id, double Amount, OrderStatus Status)
{
    internal OrderResponse(Order.Services.Models.Order order)
        : this(order.Id, order.Amount, order.Status)
    {
    }
}