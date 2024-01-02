using Microsoft.EntityFrameworkCore;
using Organizarty.Identity.Application.App.Consumers.Entities;
using Organizarty.Domain.Entities.Consumers;

namespace Organizarty.Identity.Infra.Database.EF.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Consumer> Consumers { get; set; } = default!;
    public DbSet<ConsumerEmailConfirmation> ConsumerEmailConfirmations { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
