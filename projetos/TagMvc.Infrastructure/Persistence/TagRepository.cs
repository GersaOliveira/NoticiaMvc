using Microsoft.EntityFrameworkCore;
using TagMvc.Domain.Entities;
using TagMvc.Domain.Interfaces;

namespace TagMvc.Infrastructure.Persistence.Repositories;

public class TagRepository : ITagRepository
{
    private readonly AppDbContext _context;

    public TagRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Tag?> GetByIdAsync(int id)
    {
        return await _context.Tags.FindAsync(id);
    }

    public async Task<IEnumerable<Tag>> GetAllAsync()
    {
        return await _context.Tags.AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(Tag tag)
    {
        await _context.Tags.AddAsync(tag);
    }

    public void Update(Tag tag)
    {
        _context.Tags.Update(tag);
    }

    public void Remove(Tag tag)
    {
        _context.Tags.Remove(tag);
    }
}