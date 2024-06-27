using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Interfaces.REST.Resources;

namespace UniRider.API.Profile.Interfaces.REST.Transform;

public static class VehicleDocumentResourceFromEntityAssembler
{
    public static VehicleDocumentResource ToResourceFromEntity(VehicleDocument document)
    {
        return new VehicleDocumentResource(
            document.Id,
            document.Brand,
            document.Model,
            document.Color,
            document.Plate,
            VehicleInsuranceResourceFromEntityAssembler.ToResourceFromEntity(document.VehicleInsurance),
            DriverLicenseResourceFromEntityAssembler.ToResourceFromEntity(document.DriverLicense));
    
    }
}