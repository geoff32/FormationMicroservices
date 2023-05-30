using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payment.Services.Abstractions;
using Payment.WebApi.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payment.WebApi.Controllers;

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

