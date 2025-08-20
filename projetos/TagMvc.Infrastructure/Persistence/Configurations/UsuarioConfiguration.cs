using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TagMvc.Domain.Entities;

namespace TagMvc.Infrastructure.Persistence.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Nome)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(u => u.Senha)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(250)
            .IsRequired();
    }
}