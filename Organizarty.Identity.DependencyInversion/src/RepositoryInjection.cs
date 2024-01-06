using Microsoft.Extensions.DependencyInjection;

namespace Organizarty.Identity.DependencyInversion;

public static class RepositoryInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddConsumersRepositories();
        services.AddThirdPartyRepositories();

        return services;
    }
}
