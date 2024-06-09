namespace UniRider.API.Payment.Domain.Model.Commands;

public record CreatePaymentCommand(string CardNumber, DateTime ExpiryDate, string CVV);