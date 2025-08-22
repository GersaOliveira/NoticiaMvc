using Microsoft.EntityFrameworkCore;
using TagMvc.Domain.Entities;
using TagMvc.Domain.Interfaces;
using TagMvc.Infrastructure.Persistence;

namespace TagMvc.Infrastructure.Persistence.Repositories;

public class NoticiaRepository : INoticiaRepository
{
    private readonly AppDbContext _context;

    public NoticiaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Noticia>> GetAllAsync()
    {
        return await _context.Noticias
            .Include(n => n.Usuario)
            .Include(n => n.NoticiaTags)
                    .ThenInclude(nt => nt.Tag)
            .OrderByDescending(n => n.Id)
            .ToListAsync();
    }

    public async Task<Noticia?> GetByIdAsync(int id)
    {
        return await _context.Noticias
            .Include(n => n.Usuario)
            .Include(n => n.NoticiaTags)
                    .ThenInclude(nt => nt.Tag)
            .FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task AddAsync(Noticia noticia)
    {
        await _context.Noticias.AddAsync(noticia);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Noticia noticia)
    {
        _context.Entry(noticia).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Noticia noticia)
        {
            if (noticia != null)
            {
               _context.Noticias.Remove(noticia);
               await _context.SaveChangesAsync();
            }
        }
}