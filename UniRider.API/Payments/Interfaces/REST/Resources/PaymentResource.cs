namespace UniRider.API.Payments.Interfaces.REST.Resources;

public record PaymentResource(int Id, string CardNumber, DateTime ExpirationDate, string CVV);
