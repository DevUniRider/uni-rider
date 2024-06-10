using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Model.Commands;
using UniRider.API.Profile.Domain.Repositories;
using UniRider.API.Profile.Domain.Services;
using UniRider.API.Shared.Domain.Repositories;

namespace UniRider.API.Profile.Application.Internal.CommandServices;

public class VehicleInsuranceCommandService(IVehicleInsuranceRepository vehicleInsuranceRepository, IUnitOfWork unitOfWork) : 
    IVehicleInsuranceCommandService
{
    public async Task<VehicleInsurance> Handle(CreateVehicleInsuranceCommand command)
    {
        var vehicleInsurance = new VehicleInsurance(command);
        await vehicleInsuranceRepository.AddAsync(vehicleInsurance);
        await unitOfWork.CompleteAsync();
        return vehicleInsurance;
    }
}