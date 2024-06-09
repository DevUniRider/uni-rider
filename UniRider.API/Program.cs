using UniRider.API.Record.Application.Internal.CommandServices;
using UniRider.API.Record.Application.Internal.OutboundServices;
using UniRider.API.Record.Application.Internal.QueryServices;
using UniRider.API.Record.Domain.Repositories;
using UniRider.API.Record.Domain.Services;

using UniRider.API.Record.Infrastructure.Hashing.BCrypt.Services;
using UniRider.API.Record.Infrastructure.Persistence.EFC.Repositories;
using UniRider.API.Record.Infrastructure.Pipeline.Middleware.Extensions;
using UniRider.API.Record.Infrastructure.Tokens.JWT.Configuration;
using UniRider.API.Record.Infrastructure.Tokens.JWT.Services;

using UniRider.API.Shared.Domain.Repositories;
using UniRider.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using UniRider.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using UniRider.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using UniRider.API.Payments.Domain.Services;
using UniRider.API.Payments.Application.Internal.CommandServices;
using UniRider.API.Payments.Application.Internal.QueryServices;
using UniRider.API.Payments.Infrastructure.Persistence.EFC.Repositories;
using UniRider.API.Payments.Domain.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "UniRider.API",
                Version = "v1",
                Description = "UniRider API",
                TermsOfService = new Uri("https://UniRider-API.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "UniRider API",
                    Email = "contact@acme.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
    });


// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Record Bounded Context Injection Configuration
// TokenSettings Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();

// Payment Bounded Context Injection Configuration
builder.Services.AddScoped<IPaymentCommandService, PaymentCommandService>();
builder.Services.AddScoped<IPaymentQueryService, PaymentQueryService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();


var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();