using SBoard.Modules.Auth.Services.Token;
using SBoard.Modules.Auth.DTOs.Requests;
using SBoard.Modules.Auth.Services.Auth;
using SBoard.Modules.Auth.Validations;
using FluentValidation;

namespace SBoard.Modules.Auth;

// TODO: add jwt and other auth services
public static class AuthExtensions
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services)
    {
        // 1. Register Services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();

        // TODO: fix this i dont know what role you need
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
            options.AddPolicy("HostOnly", policy => policy.RequireRole("Host"));
            options.AddPolicy("Universal", policy => policy.RequireRole("Host, Admin"));
        });

        // 5. FluentValidation validators
        services.AddScoped<IValidator<LoginRequest>, LoginValidator>();
        services.AddScoped<IValidator<RegisterRequest>, RegisterValidator>();

        return services;
    }
}