using System.ComponentModel.DataAnnotations;

namespace TagMvc.ViewModels.NoticiaViewModels
{
    public class CreateNoticiaViewModel
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(250, ErrorMessage = "O título pode ter no máximo 250 caracteres.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O texto da notícia é obrigatório.")]
        [Display(Name = "Conteúdo")]
        public string Texto { get; set; }

        [Display(Name = "Tags (separadas por vírgula)")]
        public string Tags { get; set; }
    }
}
