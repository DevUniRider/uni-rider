using UniRider.API.Record.Domain.Model.Commands;
using UniRider.API.Record.Interfaces.REST.Resources;

namespace UniRider.API.Record.Interfaces.REST.Transform;

public class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}