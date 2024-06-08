using UniRider.API.Record.Application.Internal.OutboundServices;
using UniRider.API.Record.Domain.Model.Queries;
using UniRider.API.Record.Domain.Services;
using UniRider.API.Record.Infrastructure.Pipeline.Middleware.Attributes;

namespace UniRider.API.Record.Infrastructure.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(
        HttpContext context,
        IUserQueryService userQueryService,
        ITokenService tokenService)
    {
        Console.WriteLine("Entering InvokeAsync");
        var allowAnonymous = context.Request.HttpContext.GetEndpoint()!.Metadata
            .Any(m => m.GetType() == typeof(AllowAnonymousAttribute));
        Console.WriteLine($"Allow Anonymous is {allowAnonymous}");
        if (allowAnonymous)
        {
            Console.WriteLine("Skipping authorization");
            await next(context);
            return;
        }
        Console.WriteLine("Entering authorization");
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        
        if (token == null) throw new Exception("Null or invalid token");
        
        var userId = await tokenService.ValidateToken(token);
        
        if (userId == null) throw new Exception("Invalid token");
        
        var getUserByIdQuery = new GetUserByIdQuery(userId.Value);

        var user = await userQueryService.Handle(getUserByIdQuery);
        Console.WriteLine("Successful authorization. Updating Context...");
        context.Items["User"] = user;
        Console.WriteLine("Continuing with Middleware Pipeline");

        await next(context);
    }
}