using UniRider.API.Profile.Domain.Model.Commands;
using UniRider.API.Profile.Interfaces.REST.Resources;

namespace UniRider.API.Profile.Interfaces.REST.Transform;

public static class CreateDriverLicenseCommandFromResourceAssembler
{
    public static CreateDriverLicenseCommand ToCommandFromResource(CreateDriverLicenseResource resource)
    {
        return new CreateDriverLicenseCommand(resource.Type, resource.Number, resource.ExpeditionDate,
            resource.ExpirationDate);
    }
}