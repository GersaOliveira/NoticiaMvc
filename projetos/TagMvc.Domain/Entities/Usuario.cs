namespace TagMvc.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Propriedade de navegação para o relacionamento 1-N com Noticia
    public ICollection<Noticia> Noticias { get; set; } = new List<Noticia>();
}