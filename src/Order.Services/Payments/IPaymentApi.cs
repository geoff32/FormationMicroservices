using Refit;

namespace Order.Services.Payments;

public interface IPaymentApi
{
    [Post("/api/payments")]
    Task<ValidatePaymentResponse> ValidateAsync([Body] ValidatePaymentRequest request);
}
