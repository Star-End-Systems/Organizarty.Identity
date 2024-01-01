using Microsoft.Extensions.DependencyInjection;
using Organizarty.Identity.Adapters.EmailSenders;
using Organizarty.Identity.Infra.Providers.EmailSenders;

namespace Organizarty.Identity.DependencyInversion.Providers.EmailSenders;

internal static class EmailSenderInjection
{
    public static IServiceCollection AddEmailSender(this IServiceCollection services, bool isDevelopment = true)
    {
        if (isDevelopment)
        {
            services.AddLocalEmailSender();
        }
        else
        {
            services.AddRealEmailSender();
        }

        return services;
    }

    private static IServiceCollection AddLocalEmailSender(this IServiceCollection services)
    {
        services.AddScoped<IEmailSender, LocalEmailSender>();

        return services;
    }

    private static IServiceCollection AddRealEmailSender(this IServiceCollection services)
    {
        services.AddScoped<IEmailSender, OrganizartyEmailSender>();

        return services;
    }
}
