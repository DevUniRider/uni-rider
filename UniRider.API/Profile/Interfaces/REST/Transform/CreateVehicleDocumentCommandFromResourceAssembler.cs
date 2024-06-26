using UniRider.API.Profile.Domain.Model.Commands;
using UniRider.API.Profile.Interfaces.REST.Resources;

namespace UniRider.API.Profile.Interfaces.REST.Transform;

public static class CreateVehicleDocumentCommandFromResourceAssembler
{
    public static CreateVehicleDocumentCommand ToCommandFromResource(CreateVehicleDocumentResource resource)
    {
        return new CreateVehicleDocumentCommand(resource.Brand, resource.Model, resource.Color, resource.Plate,
            resource.DriverLicenseId, resource.VehicleInsuranceId);
    }
}