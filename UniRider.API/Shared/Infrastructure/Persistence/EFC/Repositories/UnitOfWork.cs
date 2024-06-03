using UniRider.API.Shared.Domain.Repositories;
using UniRider.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace UniRider.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync() => await context.SaveChangesAsync();
}