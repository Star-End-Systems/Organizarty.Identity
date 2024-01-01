using Microsoft.Extensions.DependencyInjection;
using Organizarty.Identity.Adapters.Cryptographies;
using Organizarty.Identity.Infra.Providers.Cryptographys;
using Organizarty.Identity.DependencyInversion.Providers.EmailSenders;
using Organizarty.Identity.Adapters.Tokens;
using Organizarty.Identity.Infra.Providers.Tokens;

namespace Organizarty.Identity.DependencyInversion;

public static class ProvidersInjection
{
    public static IServiceCollection AddProviders(this IServiceCollection services)
    {
        services.AddScoped<ICryptographys, BCryptProvider>();
        services.AddScoped<IWebTokenProvider, JwtWebTokenProvider>();

        services.AddEmailSender();

        return services;
    }
}
