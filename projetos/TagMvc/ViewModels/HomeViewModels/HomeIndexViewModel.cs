using TagMvc.Domain.Entities;

namespace TagMvc.ViewModels.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Noticia> Noticia { get; set; } = new List<Noticia>();
    }
}