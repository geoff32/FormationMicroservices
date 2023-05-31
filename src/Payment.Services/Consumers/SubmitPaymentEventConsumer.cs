using Events.Common;
using MassTransit;
using Payment.Services.Abstractions;

namespace Payment.Services.Consumers;

public class SubmitPaymentEventConsumer : IConsumer<SubmitPaymentEvent>
{
    private readonly IPaymentService _paymentService;

    public SubmitPaymentEventConsumer(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public async Task Consume(ConsumeContext<SubmitPaymentEvent> context)
    {
        var message = context.Message;
        await _paymentService.SubmitPaymentAsync(message.OrderId, message.Amount);
    }
}
