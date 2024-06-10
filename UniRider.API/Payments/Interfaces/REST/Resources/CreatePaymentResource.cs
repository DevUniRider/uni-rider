namespace UniRider.API.Payments.Interfaces.REST.Resources;

public record CreatePaymentResource(string CardNumber, DateTime ExpirationDate, string CVV);