using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Interfaces.REST.Resources;

namespace UniRider.API.Profile.Interfaces.REST.Transform;

public static class VehicleInsuranceResourceFromEntityAssembler
{
    public static VehicleInsuranceResource ToResourceFromEntity(VehicleInsurance insurance)
    {
        return new VehicleInsuranceResource(
            insurance.Id,
            insurance.PolicyNumber,
            insurance.Insurer,
            insurance.StartDate,
            insurance.ExpirationDate);
    }
}