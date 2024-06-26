using Microsoft.EntityFrameworkCore;
using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Repositories;
using UniRider.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using UniRider.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace UniRider.API.Profile.Infrastructure.Persistence.EFC.Repositories;

public class VehicleInsuranceRepository : BaseRepository<VehicleInsurance>, IVehicleInsuranceRepository
{
    public VehicleInsuranceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<VehicleInsurance>> FindAllByPolicyNumberAsync(string policyNumber)
    {
        return await Context.Set<VehicleInsurance>().Where(insurance => insurance.PolicyNumber == policyNumber).ToListAsync();
    }
}