using Gatherly.Application.Contracts.Persistence;
using Gatherly.Persistence.Repositories.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gatherly.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GatherlyDbContext>(optionsAction =>
        {
            optionsAction.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IMemberRepository, MemberRepository>();

        return services;
    }
}
