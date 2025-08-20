namespace TagMvc.Domain.Entities;

public class NoticiaTag
{
    public int Id { get; set; }

    public int NoticiaId { get; set; }
    public Noticia Noticia { get; set; } = null!;

    public int TagId { get; set; }
    public Tag Tag { get; set; } = null!;
}