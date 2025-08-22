using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TagMvc.Domain.Entities;

namespace TagMvc.Infrastructure.Persistence.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        // As propriedades herdadas de IdentityUser (Id, Email, PasswordHash, etc.)
        // já são configuradas pelo IdentityDbContext.
        // A tabela também já é nomeada para "AspNetUsers" por padrão.
        // Portanto, configurei apenas as propriedades personalizadas.
        builder.Property(u => u.Nome)
            .HasMaxLength(250)
            .IsRequired();
    }
}