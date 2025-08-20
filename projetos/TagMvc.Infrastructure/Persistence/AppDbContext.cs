using Microsoft.EntityFrameworkCore;
using TagMvc.Domain.Entities;
using System.Reflection;

namespace TagMvc.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Noticia> Noticias { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<NoticiaTag> NoticiaTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}