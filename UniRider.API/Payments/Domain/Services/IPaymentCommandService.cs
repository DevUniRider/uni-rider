using UniRider.API.Payments.Domain.Model.Aggregates;
using UniRider.API.Payments.Domain.Model.Commands;

namespace UniRider.API.Payments.Domain.Services;

public interface IPaymentCommandService
{
    Task<Payment?> Handle(CreatePaymentCommand command);
}