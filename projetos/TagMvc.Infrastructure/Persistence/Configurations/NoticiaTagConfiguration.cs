using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TagMvc.Domain.Entities;

namespace TagMvc.Infrastructure.Persistence.Configurations;

public class NoticiaTagConfiguration : IEntityTypeConfiguration<NoticiaTag>
{
    public void Configure(EntityTypeBuilder<NoticiaTag> builder)
    {
        builder.ToTable("NoticiaTags");
        builder.HasKey(nt => nt.Id);

        builder.HasOne(nt => nt.Noticia)
            .WithMany(n => n.NoticiaTags)
            .HasForeignKey(nt => nt.NoticiaId);

        builder.HasOne(nt => nt.Tag)
            .WithMany(t => t.NoticiaTags)
            .HasForeignKey(nt => nt.TagId);
    }
}