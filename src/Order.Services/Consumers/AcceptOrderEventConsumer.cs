using Events.Common;
using MassTransit;
using Order.Services.Abstractions;

namespace Order.Services.Consumers
{
    public class AcceptOrderEventConsumer : IConsumer<AcceptOrderEvent>
    {
        private readonly IOrderService _orderService;

        public AcceptOrderEventConsumer(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Consume(ConsumeContext<AcceptOrderEvent> context)
        {
            await _orderService.AcceptOrderAsync(context.Message.OrderId);
        }
    }
}
