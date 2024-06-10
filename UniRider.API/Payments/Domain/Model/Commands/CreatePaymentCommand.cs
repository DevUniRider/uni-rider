namespace UniRider.API.Payments.Domain.Model.Commands;

public record CreatePaymentCommand(string CardNumber, DateTime ExpirationDate, string CVV);