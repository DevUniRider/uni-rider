using UniRider.API.Payments.Domain.Model.Aggregates;
using UniRider.API.Payments.Domain.Model.Commands;
using UniRider.API.Payments.Domain.Model.Queries;
using UniRider.API.Payments.Domain.Services;

namespace UniRider.API.Payments.Interfaces.ACL.Services;

public class PaymentsContextFacade: IPaymentsContextFacade
{
    private readonly IPaymentCommandService _paymentCommandService;
    private readonly IPaymentQueryService _paymentQueryService;

    public PaymentsContextFacade(IPaymentCommandService paymentCommandService, IPaymentQueryService paymentQueryService)
    {
        _paymentCommandService = paymentCommandService;
        _paymentQueryService = paymentQueryService;
    }
    
    public async Task<int> CreatePayment(string cardNumber, DateTime expirationDate, string cvv)
    {
        var createPaymentCommand = new CreatePaymentCommand(cardNumber, expirationDate, cvv);
        var payment = await _paymentCommandService.Handle(createPaymentCommand);
        return payment?.Id ?? 0;
    }
    
    public async Task<Payment?> GetPaymentById(int paymentId)
    {
        var getPaymentByIdQuery = new GetPaymentByIdQuery(paymentId);
        return await _paymentQueryService.Handle(getPaymentByIdQuery);
    }
}