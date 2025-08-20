using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TagMvc.Domain.Entities;

namespace TagMvc.Infrastructure.Persistence.Configurations;

public class NoticiaConfiguration : IEntityTypeConfiguration<Noticia>
{
    public void Configure(EntityTypeBuilder<Noticia> builder)
    {
        builder.ToTable("Noticias");
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Titulo)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(n => n.Texto)
            .HasColumnType("text")
            .IsRequired();

        builder.HasOne(n => n.Usuario)
            .WithMany(u => u.Noticias)
            .HasForeignKey(n => n.UsuarioId);
    }
}