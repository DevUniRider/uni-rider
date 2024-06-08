using UniRider.API.Record.Domain.Model.Aggregates;
using UniRider.API.Record.Interfaces.REST.Resources;

namespace UniRider.API.Record.Interfaces.REST.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}