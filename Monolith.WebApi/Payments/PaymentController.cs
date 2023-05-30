using Microsoft.AspNetCore.Mvc;
using Monolith.WebApi.Payments.Models;
using Payment.Services.Abstractions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monolith.WebApi.Payments;

[ApiController]
[Route("api/payments")]
public class PaymentController : Controller
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitPayment([FromBody] ValidatePaymentRequest request)
    {
        var payment = await _paymentService.SubmitPaymentAsync(request.OrderId, request.Amount);
        return base.Ok(new ValidatePaymentResponse(payment));
    }
}

