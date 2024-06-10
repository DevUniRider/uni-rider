using UniRider.API.Record.Domain.Model.Aggregates;
using UniRider.API.Record.Domain.Model.Commands;
namespace UniRider.API.Record.Domain.Services;

public interface IUserCommandService
{
    Task<(User user, string token)> Handle(SignInCommand command);
    Task Handle(SignUpCommand command);
}