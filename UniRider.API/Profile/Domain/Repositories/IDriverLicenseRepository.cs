using UniRider.API.Profile.Domain.Model.Aggregates;
using UniRider.API.Shared.Domain.Repositories;

namespace UniRider.API.Profile.Domain.Repositories;

public interface IDriverLicenseRepository : IBaseRepository<DriverLicense>
{
    Task<IEnumerable<DriverLicense>> FindAllByTypeAsync(string type);
    Task<IEnumerable<DriverLicense>> FindAllByNumberAsync(string number);
    Task<IEnumerable<DriverLicense>> FindAllByExpeditionDateAsync(string expeditionDate);
}