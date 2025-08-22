using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TagMvc.Application.Interfaces;
using TagMvc.ViewModels;
using TagMvc.ViewModels.HomeViewModels;
using System.Threading.Tasks;

namespace TagMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INoticiaService _noticiaService;

        public HomeController(ILogger<HomeController> logger, INoticiaService noticiaService)
        {
            _logger = logger;
            _noticiaService = noticiaService;
        }

        public async Task<IActionResult> Index()
        {
            var noticias = await _noticiaService.GetAllAsync();
            var viewModel = new HomeIndexViewModel
            {
                Noticia = noticias
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
