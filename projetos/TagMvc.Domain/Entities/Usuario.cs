using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TagMvc.Domain.Entities;

public class Usuario : IdentityUser
{
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    public ICollection<Noticia> Noticias { get; set; } = new List<Noticia>();
}