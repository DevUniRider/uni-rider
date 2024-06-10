using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Shared.Domain.Repositories;

namespace UniRider.API.Profile.Domain.Repositories;

public interface IVehicleInsuranceRepository : IBaseRepository<VehicleInsurance>
{
    Task<IEnumerable<VehicleInsurance>> FindAllByPolicyNumberAsync(string policyNumber);
}