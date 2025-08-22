using System.ComponentModel.DataAnnotations;

namespace TagMvc.ViewModels.AccountViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
    [Display(Name = "Nome Completo")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
    [Display(Name = "Nome de Usuário")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O e-mail não é válido.")]
    [Display(Name = "E-mail")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [StringLength(100, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirmar senha")]
    [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não correspondem.")]
    public string ConfirmPassword { get; set; }
}