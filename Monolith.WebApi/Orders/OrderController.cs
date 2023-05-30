using Microsoft.AspNetCore.Mvc;
using Monolith.WebApi.Orders.Models;
using Order.Services.Abstractions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monolith.WebApi.Orders;

[ApiController]
[Route("api/orders")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        return Ok(new GetOrdersResponse(await _orderService.GetOrders()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        return Ok(await _orderService.CreateOrderAsync(request.Amount));
    }
}

