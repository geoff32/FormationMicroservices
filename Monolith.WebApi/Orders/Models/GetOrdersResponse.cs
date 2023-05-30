namespace Monolith.WebApi.Orders.Models;

public record GetOrdersResponse(IEnumerable<OrderResponse> Orders, int Count)
{
    public GetOrdersResponse(IEnumerable<Order.Services.Models.Order> orders)
        : this(orders.Select(order => new OrderResponse(order)), orders.Count())
    {

    }
}

