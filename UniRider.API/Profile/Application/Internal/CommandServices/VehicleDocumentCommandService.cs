using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Model.Commands;
using UniRider.API.Profile.Domain.Repositories;
using UniRider.API.Profile.Domain.Services;
using UniRider.API.Shared.Domain.Repositories;

namespace UniRider.API.Profile.Application.Internal.CommandServices;

public class VehicleDocumentCommandService(IVehicleDocumentRepository vehicleDocumentRepository, IUnitOfWork unitOfWork) : 
    IVehicleDocumentCommandService
{
    public async Task<VehicleDocument> Handle(CreateVehicleDocumentCommand command)
    {
        var vehicleDocument = new VehicleDocument(command);
        await vehicleDocumentRepository.AddAsync(vehicleDocument);
        await unitOfWork.CompleteAsync();
        return vehicleDocument;
    }
}