using System.ComponentModel.DataAnnotations;

namespace TagMvc.ViewModels.ProductViewModels;

public class CreateProductViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O preço é obrigatório")]
    public decimal Price { get; set; }
}