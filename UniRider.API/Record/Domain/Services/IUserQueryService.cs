using UniRider.API.Record.Domain.Model.Aggregates;
using UniRider.API.Record.Domain.Model.Queries;
namespace UniRider.API.Record.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}