using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Shared.Domain.Repositories;

namespace UniRider.API.Profile.Domain.Repositories;

public interface IVehicleDocumentRepository : IBaseRepository<VehicleDocument>
{
    Task<IEnumerable<VehicleDocument>> FindAllByBrandAndModelAsync(string brand, string model);
    Task<IEnumerable<VehicleDocument>> FindAllByPlateAsync(string plate);
}