using  UniRider.API.Payments.Domain.Model.Aggregates;
using  UniRider.API.Payments.Interfaces.REST.Resources;

namespace UniRider.API.Payments.Interfaces.REST.Transform;

public class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Payment entity)
    {
        return new PaymentResource(entity.Id, entity.Cardnumber.Value, entity.Expirationdate.Value, entity.Cardverification.Value);
    }
}