using Microsoft.Extensions.DependencyInjection;
using MyMocker.Models;

namespace MyMocker.Server;

public static class ServicesConfiguration
{
    internal static IServiceCollection AddServices(this IServiceCollection services, Resources resources)
    {
        services.AddSingleton<Resources>(resources);
        services.AddSingleton<IRepository, Repository>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}