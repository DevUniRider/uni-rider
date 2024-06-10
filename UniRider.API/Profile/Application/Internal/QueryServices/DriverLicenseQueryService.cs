using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Model.Queries;
using UniRider.API.Profile.Domain.Repositories;
using UniRider.API.Profile.Domain.Services;

namespace UniRider.API.Profile.Application.Internal.QueryServices;

public class DriverLicenseQueryService(IDriverLicenseRepository driverLicenseRepository) : 
    IDriverLicenseQueryService
{
    public async Task<DriverLicense> Handle(GetAllDriverLicenseByIdQuery query)
    {
        return await driverLicenseRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<DriverLicense>> Handle(GetAllDriverLicenseByNumberQuery query)
    {
        return await driverLicenseRepository.FindAllByNumberAsync(query.Number);
    }

    public async Task<IEnumerable<DriverLicense>> Handle(GetAllDriverLicenseByTypeQuery query)
    {
        return await driverLicenseRepository.FindAllByTypeAsync(query.Type);
    }

    public async Task<IEnumerable<DriverLicense>> Handle(GetAllDriverLicenseByExpeditionDateQuery query)
    {
        return await driverLicenseRepository.FindAllByExpeditionDateAsync(query.ExpeditionDate);
    }
}