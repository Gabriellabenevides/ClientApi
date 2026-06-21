using Core.Interfaces;
using Infra.Repositories;
using Infra.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC;

public static class AddRepositorySetup
{
    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
    {

        // Registra os repositórios genéricos como tipos abertos
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IClientRepository, ClientRepository>();

        return services;
    }
}
