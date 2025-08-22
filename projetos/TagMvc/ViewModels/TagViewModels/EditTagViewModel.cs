using System.ComponentModel.DataAnnotations;

namespace TagMvc.ViewModels.TagViewModels;

public class EditTagViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [StringLength(100, ErrorMessage = "A descrição não pode ter mais de 100 caracteres.")]
    public string Descricao { get; set; }
}