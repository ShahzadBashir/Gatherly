using Microsoft.Extensions.DependencyInjection;

namespace Gatherly.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ApplicationServicesRegistration).Assembly));
        return services;
    }
}
