using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TagMvc.Application.Interfaces;
using TagMvc.Domain.Entities;
using TagMvc.ViewModels.NoticiaViewModels;
using System;

namespace TagMvc.Controllers
{
    [Authorize]
    public class NoticiaController : Controller
    {
        private readonly INoticiaService _noticiaService;
        private readonly UserManager<Usuario> _userManager;

        public NoticiaController(INoticiaService noticiaService, UserManager<Usuario> userManager)
        {
            _noticiaService = noticiaService;
            _userManager = userManager;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNoticiaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                if (userId == null)
                {
                    return Unauthorized();
                }

                var noticia = new Noticia
                {
                    Titulo = model.Titulo,
                    Texto = model.Texto,
                    UsuarioId = userId,
                };

                await _noticiaService.AddAsync(noticia, model.Tags);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _noticiaService.GetByIdAsync(id.Value);
            if (noticia == null)
            {
                return NotFound();
            }

            if (noticia.UsuarioId != _userManager.GetUserId(User))
            {
                return Forbid(); 
            }

            return View(noticia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noticia = await _noticiaService.GetByIdAsync(id);
            if (noticia?.UsuarioId != _userManager.GetUserId(User))
            {
                return Forbid();
            }

            await _noticiaService.RemoveAsync(id);
            return RedirectToAction("Index", "Home");
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _noticiaService.GetByIdAsync(id.Value);
            if (noticia == null)
            {
                return NotFound();
            }

            if (noticia.UsuarioId != _userManager.GetUserId(User) && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            var viewModel = new EditNoticiaViewModel
            {
                Id = noticia.Id,
                Titulo = noticia.Titulo,
                Texto = noticia.Texto,
                Tags = string.Join(", ", noticia.NoticiaTags.Select(nt => nt.Tag.Descricao))
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditNoticiaViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var noticiaToUpdate = await _noticiaService.GetByIdAsync(id);
                if (noticiaToUpdate == null || (noticiaToUpdate.UsuarioId != _userManager.GetUserId(User) && !User.IsInRole("Admin")))
                {
                    return Forbid();
                }

                noticiaToUpdate.Titulo = model.Titulo;
                noticiaToUpdate.Texto = model.Texto;

                await _noticiaService.UpdateAsync(noticiaToUpdate, model.Tags);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
