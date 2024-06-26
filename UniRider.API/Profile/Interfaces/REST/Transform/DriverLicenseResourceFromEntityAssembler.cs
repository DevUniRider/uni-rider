using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Interfaces.REST.Resources;

namespace UniRider.API.Profile.Interfaces.REST.Transform;

public static class DriverLicenseResourceFromEntityAssembler
{
    public static DriverLicenseResource ToResourceFromEntity(DriverLicense license)
    {
        return new DriverLicenseResource(
            license.Id,
            license.Type,
            license.Number,
            license.ExpeditionDate,
            license.ExpirationDate);
    }
}