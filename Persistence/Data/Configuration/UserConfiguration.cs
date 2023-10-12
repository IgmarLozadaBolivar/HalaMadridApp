using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasComment("ID del usuario")
        .HasMaxLength(3);

        builder.Property(f => f.Email)
        .IsRequired()
        .HasColumnName("Email")
        .HasComment("Correo del usuario")
        .HasColumnType("varchar(150)")
        .HasMaxLength(150);

        builder.Property(f => f.Username)
        .IsRequired()
        .HasColumnName("Username")
        .HasComment("Nombre del usuario")
        .HasColumnType("varchar(50)")
        .HasMaxLength(50);

        builder.Property(f => f.Password)
        .IsRequired()
        .HasColumnName("Password")
        .HasComment("Contraseña del usuario")
        .HasColumnType("varchar(100)")
        .HasMaxLength(100);
    }
}