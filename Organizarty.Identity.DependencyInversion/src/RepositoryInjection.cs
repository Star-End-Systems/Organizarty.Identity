using Microsoft.Extensions.DependencyInjection;
using Organizarty.Identity.Application.App.Consumers.Data;
using Organizarty.Identity.Infra.Database.EF.Repositories;

namespace Organizarty.Identity.DependencyInversion;

public static class RepositoryInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IConsumerRepository, EFConsumerRepository>();

        return services;
    }
}
