using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SBoard.Modules.Auth;
using FluentValidation;
using SBoard.Data;

namespace SBoard.Core.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDatabaseServices(configuration);
        services.AddModuleServices();
        services.AddBasicServices();
        services.AddOtherServices(configuration);
        services.AddSignalR();
        return services;
    }

    private static IServiceCollection AddBasicServices(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    private static IServiceCollection AddDatabaseServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    private static IServiceCollection AddModuleServices(this IServiceCollection services)
    {
        services.AddAuthModule();

        return services;
    }

    private static IServiceCollection AddOtherServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(Program).Assembly);

        services.AddValidatorsFromAssemblyContaining<Program>();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins(configuration.GetConnectionString("Frontend")!)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return services;
    }
}