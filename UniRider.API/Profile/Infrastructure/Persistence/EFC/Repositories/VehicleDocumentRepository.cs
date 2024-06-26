using Microsoft.EntityFrameworkCore;
using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Repositories;
using UniRider.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using UniRider.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace UniRider.API.Profile.Infrastructure.Persistence.EFC.Repositories;

public class VehicleDocumentRepository : BaseRepository<VehicleDocument>, IVehicleDocumentRepository
{
    
    public VehicleDocumentRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<VehicleDocument>> FindAllByBrandAndModelAsync(string brand, string model)
    {
        return await Context.Set<VehicleDocument>().Where(document => document.Brand == brand && document.Model == model).ToListAsync();
    }

    public async Task<IEnumerable<VehicleDocument>> FindAllByPlateAsync(string plate)
    {
        return await Context.Set<VehicleDocument>().Where(document => document.Plate == plate).ToListAsync();
    }
}