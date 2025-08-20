namespace TagMvc.Domain.Entities;

public class Noticia
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Texto { get; set; } = string.Empty;

    // Chave estrangeira para Usuario
    public int UsuarioId { get; set; }
    // Propriedade de navegação para Usuario
    public Usuario Usuario { get; set; } = null!;

    // Propriedade de navegação para a tabela de junção
    public ICollection<NoticiaTag> NoticiaTags { get; set; } = new List<NoticiaTag>();
}