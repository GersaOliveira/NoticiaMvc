namespace TagMvc.Domain.Entities;

public class Tag
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;

    public ICollection<NoticiaTag> NoticiaTags { get; set; } = new List<NoticiaTag>();
}