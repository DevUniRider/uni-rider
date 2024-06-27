using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Model.Queries;

namespace UniRider.API.Profile.Domain.Services;

public interface IVehicleDocumentQueryService
{
    Task<VehicleDocument?> Handle(GetAllVehicleDocumentByIdQuery query);
    Task<IEnumerable<VehicleDocument>> Handle(GetAllVehicleDocumentByPlateQuery query);
    Task<IEnumerable<VehicleDocument>> Handle(GetAllVehicleDocumentByBrandAndModelQuery query);
    Task<IEnumerable<VehicleDocument>> Handle(GetAllVehicleDocumentsQuery query);
}