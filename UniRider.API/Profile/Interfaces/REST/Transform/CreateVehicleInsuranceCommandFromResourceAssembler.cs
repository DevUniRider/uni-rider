using UniRider.API.Profile.Domain.Model.Commands;
using UniRider.API.Profile.Interfaces.REST.Resources;

namespace UniRider.API.Profile.Interfaces.REST.Transform;

public static class CreateVehicleInsuranceCommandFromResourceAssembler
{
    public static CreateVehicleInsuranceCommand ToCommandFromResource(CreateVehicleInsuranceResource resource)
    {
        return new CreateVehicleInsuranceCommand(resource.PolicyNumber, resource.Insurer, resource.StartDate,
            resource.ExpirationDate);
    }
}