using UniRider.API.Record.Infrastructure.Pipeline.Middleware.Components;
    
namespace UniRider.API.Record.Infrastructure.Pipeline.Middleware.Extensions;

public static class RequestAuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestAuthorizationMiddleware>();
    }
}