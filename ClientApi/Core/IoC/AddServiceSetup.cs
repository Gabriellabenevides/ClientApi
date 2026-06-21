using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.IoC;

public static class AddServiceSetup
{
    public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IClientService, ClientService>();

        return services;
    }
}
