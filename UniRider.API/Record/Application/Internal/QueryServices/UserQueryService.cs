using UniRider.API.Record.Domain.Model.Aggregates;
using UniRider.API.Record.Domain.Model.Queries;
using UniRider.API.Record.Domain.Repositories;
using UniRider.API.Record.Domain.Services;

namespace UniRider.API.Record.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }
    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
}