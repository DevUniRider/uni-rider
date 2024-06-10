using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Model.Queries;
using UniRider.API.Profile.Domain.Repositories;
using UniRider.API.Profile.Domain.Services;

namespace UniRider.API.Profile.Application.Internal.QueryServices;

public class VehicleDocumentQueryService(IVehicleDocumentRepository vehicleDocumentRepository) :
    IVehicleDocumentQueryService
{
    public async Task<VehicleDocument> Handle(GetAllVehicleDocumentByIdQuery query)
    {
        return await vehicleDocumentRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<VehicleDocument>> Handle(GetAllVehicleDocumentByPlateQuery query)
    {
        return await vehicleDocumentRepository.FindAllByPlateAsync(query.Plate);
    }

    public async Task<IEnumerable<VehicleDocument>> Handle(GetAllVehicleDocumentByBrandAndModelQuery query)
    {
        return await vehicleDocumentRepository.FindAllByBrandAndModelAsync(query.Brand, query.Model);
    }
}