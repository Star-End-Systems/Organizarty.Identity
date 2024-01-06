using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Domain.Identifiers;
using Organizarty.Identity.Application.App.ThirdParties.Entities;

namespace LivrariaOnline.Backend.Infra.Database.EF.Configurations;

public class ThirdPartyConfiguration : IEntityTypeConfiguration<ThirdParty>
{
    public void Configure(EntityTypeBuilder<ThirdParty> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Id).HasMaxLength(IdGenerator.ID_SIZE);

        builder.Property(x => x.Name).HasMaxLength(64);

        builder.Property(x => x.Description).HasMaxLength(512);
        builder.Property(x => x.PhoneNumber).HasMaxLength(20);

        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(90);
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.ContactEmail).HasMaxLength(90);
        builder.Property(x => x.ContactPhone).HasMaxLength(90);

        builder.Property(x => x.CNPJ).IsRequired();
        builder.Property(x => x.CNPJ).HasMaxLength(14);
        builder.HasIndex(x => x.CNPJ).IsUnique();

        builder.Property(x => x.HashedPassword).IsRequired();
        builder.Property(x => x.Salt).IsRequired();

        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd();
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnAdd();
    }
}
