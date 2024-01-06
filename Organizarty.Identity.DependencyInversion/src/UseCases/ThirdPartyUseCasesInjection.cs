using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Identity.Application.App.ThirdParties.UseCases;

namespace Organizarty.Identity.DependencyInversion;

public static class ThirdPartyUseCasesInjection
{
    public static IServiceCollection AddThirdPartyUseCases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ThirdPartyValidation>();

        services.AddScoped<RegisterThirdPartyUseCase>();

        return services;
    }
}
