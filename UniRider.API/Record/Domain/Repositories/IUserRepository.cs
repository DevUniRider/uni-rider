using UniRider.API.Record.Domain.Model.Aggregates;
using UniRider.API.Shared.Domain.Repositories;
namespace UniRider.API.Record.Domain.Repositories;

public interface IUserRepository: IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
    
}