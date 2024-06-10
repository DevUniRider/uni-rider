using UniRider.API.Record.Domain.Model.Commands;
using UniRider.API.Record.Interfaces.REST.Resources;

namespace UniRider.API.Record.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}