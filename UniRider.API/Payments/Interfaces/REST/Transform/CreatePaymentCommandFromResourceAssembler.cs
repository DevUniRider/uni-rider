using UniRider.API.Payments.Domain.Model.Commands;
using UniRider.API.Payments.Interfaces.REST.Resources;

namespace UniRider.API.Payments.Interfaces.REST.Transform;

public class CreatePaymentCommandFromResourceAssembler
{
    public static CreatePaymentCommand ToCommandFromResource(CreatePaymentResource resource)
    {
        return new CreatePaymentCommand(resource.CardNumber, resource.ExpirationDate, resource.CVV);
    }
}