using TagMvc.Domain.Entities;

namespace TagMvc.Application.Interfaces;

public interface INoticiaService
{
    Task<IEnumerable<Noticia>> GetAllAsync();
    Task<Noticia?> GetByIdAsync(int id);
    Task AddAsync(Noticia noticia, string tagsCsv);
    Task UpdateAsync(Noticia noticia, string tagsCsv); // Altera o UpdateAsync
    Task RemoveAsync(int id);
}

