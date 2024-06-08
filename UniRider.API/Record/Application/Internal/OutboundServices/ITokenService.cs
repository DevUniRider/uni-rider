using UniRider.API.Record.Domain.Model.Aggregates;

namespace UniRider.API.Record.Application.Internal.OutboundServices;

public interface ITokenService{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}