using Microsoft.EntityFrameworkCore;
using TagMvc.Domain.Entities;
using TagMvc.Domain.Interfaces;
using TagMvc.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TagMvc.Infrastructure.Persistence.Repositories
{
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
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag?> GetByDescAsync(string nome)
        {
      
            return await _context.Tags
                .FirstOrDefaultAsync(t => t.Descricao.ToLower() == nome.ToLower());
        }

        public async Task AddAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
        }

        public void Update(Tag tag)
        {
            _context.Entry(tag).State = EntityState.Modified;
        }

        public void Remove(Tag tag)
        {
            _context.Tags.Remove(tag);
        }
    }
}