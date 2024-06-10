using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Model.Commands;
using UniRider.API.Profile.Domain.Repositories;
using UniRider.API.Profile.Domain.Services;
using UniRider.API.Shared.Domain.Repositories;

namespace UniRider.API.Profile.Application.Internal.CommandServices;

public class DriverLicenseCommandService(IDriverLicenseRepository driverLicenseRepository, IUnitOfWork unitOfWork) : 
    IDriverLicenseCommandService
{
    public async Task<DriverLicense> Handle(CreateDriverLicenseCommand command)
    {
        var driverLicense = new DriverLicense(command);
        await driverLicenseRepository.AddAsync(driverLicense);
        await unitOfWork.CompleteAsync();
        return driverLicense;
    }
}