using System.ComponentModel.DataAnnotations;

namespace TagMvc.ViewModels.AccountViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O e-mail não é válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Lembrar-me?")]
    public bool RememberMe { get; set; }
}