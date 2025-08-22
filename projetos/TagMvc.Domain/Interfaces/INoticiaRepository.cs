using TagMvc.Domain.Entities;

namespace TagMvc.Domain.Interfaces;

public interface INoticiaRepository
{
    Task<IEnumerable<Noticia>> GetAllAsync();
    Task<Noticia?> GetByIdAsync(int id);
    Task AddAsync(Noticia noticia);
    Task Update(Noticia noticia);
    Task Remove(Noticia noticia);
}