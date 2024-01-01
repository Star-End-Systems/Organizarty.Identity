using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Domain.Identifiers;
using Organizarty.Identity.Application.App.Consumers.Entities;

namespace LivrariaOnline.Backend.Infra.Database.EF.Configurations;

public class ConsumerEmailConfirmationConfiguration : IEntityTypeConfiguration<ConsumerEmailConfirmation>
{
    public void Configure(EntityTypeBuilder<ConsumerEmailConfirmation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Id).HasMaxLength(IdGenerator.ID_SIZE);

        builder.Property(x => x.UserEmail).IsRequired();

        builder.Property(x => x.Code).IsRequired().HasMaxLength(8);

        builder.Property(x => x.GeneratedAt).ValueGeneratedOnAdd();
    }
}
