using Microsoft.AspNetCore.Mvc;
using TagMvc.Application.Interfaces;
using TagMvc.Application.Tags.Commands;
using TagMvc.ViewModels.TagViewModels;

namespace TagMvc.Controllers;

public class TagsController : Controller
{
    private readonly ITagAppService _tagAppService;

    public TagsController(ITagAppService tagAppService)
    {
        _tagAppService = tagAppService;
    }

    public async Task<IActionResult> Index()
    {
        var tagsDto = await _tagAppService.GetAllTagsAsync();
        var viewModels = tagsDto.Select(dto => new TagViewModel
        {
            Id = dto.Id,
            Descricao = dto.Descricao
        });
        return View(viewModels);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateTagViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var command = new CreateTagCommand { Descricao = viewModel.Descricao };
            await _tagAppService.CreateTagAsync(command);
            return RedirectToAction(nameof(Index));
        }
        return View(viewModel);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var tagDto = await _tagAppService.GetTagByIdAsync(id);
        if (tagDto == null)
        {
            return NotFound();
        }

        var viewModel = new EditTagViewModel
        {
            Id = tagDto.Id,
            Descricao = tagDto.Descricao
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EditTagViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                var command = new UpdateTagCommand { Id = viewModel.Id, Descricao = viewModel.Descricao };
                await _tagAppService.UpdateTagAsync(command);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        return View(viewModel);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var tagDto = await _tagAppService.GetTagByIdAsync(id);
        if (tagDto == null)
        {
            return NotFound();
        }

        var viewModel = new TagViewModel { Id = tagDto.Id, Descricao = tagDto.Descricao };
        return View(viewModel);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _tagAppService.DeleteTagAsync(id);
        return RedirectToAction(nameof(Index));
    }
}