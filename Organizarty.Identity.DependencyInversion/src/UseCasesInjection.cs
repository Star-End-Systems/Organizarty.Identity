using Microsoft.Extensions.DependencyInjection;

namespace Organizarty.Identity.DependencyInversion;

public static class UseCasesInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddUserUseCases();
        services.AddThirdPartyUseCases();

        return services;
    }
}
