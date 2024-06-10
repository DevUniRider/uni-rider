using UniRider.API.Payments.Domain.Model.Aggregates;
using UniRider.API.Payments.Domain.Model.Queries;

namespace UniRider.API.Payments.Domain.Services;

public interface IPaymentQueryService
{
    Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query);
    Task<Payment?> Handle(GetPaymentByIdQuery query);
}