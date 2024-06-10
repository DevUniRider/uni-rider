using UniRider.API.Payments.Domain.Model.Aggregates;
using UniRider.API.Payments.Domain.Model.Queries;
using UniRider.API.Payments.Domain.Repositories;
using UniRider.API.Payments.Domain.Services;

namespace UniRider.API.Payments.Application.Internal.QueryServices;

public class PaymentQueryService: IPaymentQueryService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentQueryService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query)
    {
        return await _paymentRepository.ListAsync();
    }

    public async Task<Payment?> Handle(GetPaymentByIdQuery query)
    {
        return await _paymentRepository.FindByIdAsync(query.PaymentId);
    }
}