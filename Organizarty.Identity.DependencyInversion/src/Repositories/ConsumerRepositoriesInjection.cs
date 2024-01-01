using Microsoft.Extensions.DependencyInjection;
using Organizarty.Identity.Application.App.Consumers.Data;
using Organizarty.Identity.Infra.Database.EF.Repositories;

namespace Organizarty.Identity.DependencyInversion;

internal static class ConsumerRepositoriesInjection
{
    public static IServiceCollection AddConsumersRepositories(this IServiceCollection services)
    {
        services.AddScoped<IConsumerRepository, EFConsumerRepository>();
        services.AddScoped<IConsumerEmailConfirmationRepository, EFConsumerEmailConfirmationRepository>();

        return services;
    }
}
