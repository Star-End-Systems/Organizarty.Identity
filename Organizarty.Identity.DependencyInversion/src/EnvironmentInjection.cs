using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Identity.Infra.Database.EF;

namespace Organizarty.Identity.DependencyInversion;

public static class EnvironmentInjection
{
    public static IServiceCollection AddEnvironment(this IServiceCollection services)
    {
        Env.TraversePath().Load();

        services.AddDatabase();

        return services;
    }
}
