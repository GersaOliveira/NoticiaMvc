using TagMvc.Domain.Entities;

namespace TagMvc.Domain.Interfaces;

public interface ITagRepository
{
    Task<Tag?> GetByIdAsync(int id);
    Task<IEnumerable<Tag>> GetAllAsync();
    Task AddAsync(Tag tag);
    void Update(Tag tag);
    void Remove(Tag tag);
    Task<Tag?> GetByDescAsync(string nome);
}