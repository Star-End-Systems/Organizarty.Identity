using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Identity.Application.App.Consumers.UseCases;

namespace Organizarty.Identity.DependencyInversion;

public static class ConsumerUseCasesInjection
{
    public static IServiceCollection AddUserUseCases(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ConsumerValidator>();

        services.AddScoped<RegisterConsumerUseCase>();
        services.AddScoped<LoginConsumerUseCase>();

        return services;
    }
}
