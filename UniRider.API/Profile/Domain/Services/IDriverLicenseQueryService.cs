using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Model.Queries;

namespace UniRider.API.Profile.Domain.Services;

public interface IDriverLicenseQueryService
{
    Task<DriverLicense?> Handle(GetAllDriverLicenseByIdQuery query);
    Task<IEnumerable<DriverLicense>> Handle(GetAllDriverLicenseByNumberQuery query);
    Task<IEnumerable<DriverLicense>> Handle(GetAllDriverLicenseByTypeQuery query);
    Task<IEnumerable<DriverLicense>> Handle(GetAllDriverLicenseByExpeditionDateQuery query);
    Task<IEnumerable<DriverLicense>> Handle(GetAllDriverLicensesQuery query);
}