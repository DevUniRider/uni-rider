using Microsoft.EntityFrameworkCore;
using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Repositories;
using UniRider.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using UniRider.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace UniRider.API.Profile.Infrastructure.Persistence.EFC.Repositories;

public class DriverLicenseRepository : BaseRepository<DriverLicense>, IDriverLicenseRepository
{
    public DriverLicenseRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<DriverLicense>> FindAllByTypeAsync(string type)
    {
        return await Context.Set<DriverLicense>().Where(f => f.Type == type).ToListAsync();
    }

    public async Task<IEnumerable<DriverLicense>> FindAllByNumberAsync(string number)
    {
        return await Context.Set<DriverLicense>().Where(f => f.Number == number).ToListAsync();
    }

    public async Task<IEnumerable<DriverLicense>> FindAllByExpeditionDateAsync(string expeditionDate)
    {
        return await Context.Set<DriverLicense>().Where(f => f.ExpeditionDate == expeditionDate).ToListAsync();
    }
}