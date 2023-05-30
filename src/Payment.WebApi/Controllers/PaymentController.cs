using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payment.Services.Abstractions;
using Payment.WebApi.Models;
using Polly.Contrib.Simmy;
using Polly.Contrib.Simmy.Outcomes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payment.WebApi.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentController : Controller
{
    private readonly IPaymentService _paymentService;
    private readonly InjectOutcomePolicy _chaosPolicy;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;

        _chaosPolicy = MonkeyPolicy.InjectException(with =>
            with.Fault(new SocketException(errorCode: 10013))
                .InjectionRate(0.33)
                .Enabled());
    }

    [HttpPost]
    public async Task<IActionResult> SubmitPayment([FromBody] ValidatePaymentRequest request)
    {
        var payment = await _paymentService.SubmitPaymentAsync(request.OrderId, request.Amount);
        return base.Ok(_chaosPolicy.Execute(() => new ValidatePaymentResponse(payment)));
    }
}

