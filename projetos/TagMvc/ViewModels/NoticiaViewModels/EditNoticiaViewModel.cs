using System.ComponentModel.DataAnnotations;

namespace TagMvc.ViewModels.NoticiaViewModels
{
    public class EditNoticiaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(250, ErrorMessage = "O título pode ter no máximo 250 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O texto da notícia é obrigatório.")]
        public string Texto { get; set; }

        [Display(Name = "Tags (separadas por vírgula)")]
        public string Tags { get; set; }
    }
}