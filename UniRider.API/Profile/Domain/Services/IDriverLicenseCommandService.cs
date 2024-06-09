using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Model.Commands;

namespace UniRider.API.Profile.Domain.Services;

public interface IDriverLicenseCommandService
{
    Task<DriverLicense> Handle(CreateDriverLicenseCommand command);
}