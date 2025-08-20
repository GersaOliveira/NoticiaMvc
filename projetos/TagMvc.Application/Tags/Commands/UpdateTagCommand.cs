namespace TagMvc.Application.Tags.Commands;

public class UpdateTagCommand
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
}