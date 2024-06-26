using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Model.Queries;
using UniRider.API.Profile.Domain.Repositories;
using UniRider.API.Profile.Domain.Services;

namespace UniRider.API.Profile.Application.Internal.QueryServices;

public class VehicleInsuranceQueryService(IVehicleInsuranceRepository vehicleInsuranceRepository) :
    IVehicleInsuranceQueryService
{
    public async Task<VehicleInsurance> Handle(GetAllVehicleInsuranceByIdQuery query)
    {
        return await vehicleInsuranceRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<VehicleInsurance>> Handle(GetAllVehicleInsuranceByPolicyNumberQuery query)
    {
        return await vehicleInsuranceRepository.FindAllByPolicyNumberAsync(query.PolicyNumber);
    }
    
    public async Task<IEnumerable<VehicleInsurance>> Handle(GetAllVehicleInsurancesQuery query)
    {
        return await vehicleInsuranceRepository.ListAsync();
    }
}