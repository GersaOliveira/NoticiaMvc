namespace TagMvc.Domain.Entities;

public class Noticia
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Texto { get; set; } = string.Empty;

    public string UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public ICollection<NoticiaTag> NoticiaTags { get; set; } = new List<NoticiaTag>();
}