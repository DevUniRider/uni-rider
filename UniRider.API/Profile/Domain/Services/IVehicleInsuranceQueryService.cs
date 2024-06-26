using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Model.Queries;

namespace UniRider.API.Profile.Domain.Services;

public interface IVehicleInsuranceQueryService
{
    Task<VehicleInsurance?> Handle(GetAllVehicleInsuranceByIdQuery query);
    Task<IEnumerable<VehicleInsurance>> Handle(GetAllVehicleInsuranceByPolicyNumberQuery query);
    Task<IEnumerable<VehicleInsurance>> Handle(GetAllVehicleInsurancesQuery query);

}