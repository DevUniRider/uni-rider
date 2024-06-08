using UniRider.API.Record.Domain.Model.Aggregates;
using UniRider.API.Record.Interfaces.REST.Resources;

namespace UniRider.API.Record.Interfaces.REST.Transform;

public class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}