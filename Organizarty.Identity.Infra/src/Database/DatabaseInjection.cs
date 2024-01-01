using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Organizarty.Identity.Infra.Database.EF.Contexts;

namespace Organizarty.Identity.Infra.Database.EF;

public static class UsecaseInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") ?? throw new ArgumentException("<POSTGRES_CONNECTION_STRING> not found.");

        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }
}
