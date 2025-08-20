namespace TagMvc.Domain.Entities;

public class Tag
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;

    // Propriedade de navegação para a tabela de junção
    public ICollection<NoticiaTag> NoticiaTags { get; set; } = new List<NoticiaTag>();
}