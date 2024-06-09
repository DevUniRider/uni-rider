using UniRider.API.Payments.Domain.Model.Aggregates;
namespace UniRider.API.Payments.Interfaces.ACL;

public interface IPaymentsContextFacade
{
    Task<int> CreatePayment(string cardNumber, DateTime expirationDate, string cvv);
    Task<Payment?> GetPaymentById(int paymentId);
}