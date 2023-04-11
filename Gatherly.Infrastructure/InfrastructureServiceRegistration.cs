using Gatherly.Application.Contracts.Infrastructure.Jwt;
using Gatherly.Infrastructure.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace Gatherly.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
        return services;
    }
}
