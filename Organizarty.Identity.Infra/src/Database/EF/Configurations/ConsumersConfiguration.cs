using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Domain.Entities.Consumers;
using Organizarty.Domain.Identifiers;

namespace LivrariaOnline.Backend.Infra.Database.EF.Configurations;

public class ConsumersConfiguration : IEntityTypeConfiguration<Consumer>
{
    public void Configure(EntityTypeBuilder<Consumer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Id).HasMaxLength(IdGenerator.ID_SIZE);

        builder.Property(x => x.Fullname).IsRequired().HasMaxLength(80);

        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(90);
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.HashedPassword).IsRequired();
        builder.Property(x => x.Salt).IsRequired();

        builder.Property(x => x.BirthDate).IsRequired();

        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd();
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnAdd();
    }
}
