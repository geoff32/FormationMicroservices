namespace Events.Common;

public record SubmitPaymentEvent(Guid OrderId, double Amount);
