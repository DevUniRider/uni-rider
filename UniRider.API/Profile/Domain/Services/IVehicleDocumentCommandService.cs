using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Model.Commands;

namespace UniRider.API.Profile.Domain.Services;

public interface IVehicleDocumentCommandService
{
    Task<VehicleDocument> Handle(CreateVehicleDocumentCommand command);
}