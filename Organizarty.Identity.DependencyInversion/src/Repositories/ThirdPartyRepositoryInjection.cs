using Microsoft.Extensions.DependencyInjection;
using Organizarty.Identity.Application.App.ThirdParties.Data;
using Organizarty.Identity.Infra.Database.EF.Repositories;

namespace Organizarty.Identity.DependencyInversion;

internal static class ThirdPartyRepositoryInjection
{
    public static IServiceCollection AddThirdPartyRepositories(this IServiceCollection services)
    {
        services.AddScoped<IThirdPartyRepository, EFThirdPartyRepository>();

        return services;
    }
}
