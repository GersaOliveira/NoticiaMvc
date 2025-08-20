using Microsoft.AspNetCore.Mvc;
using TagMvc.Application.Interfaces;
using TagMvc.ViewModels.TagViewModels;

namespace TagMvc.Controllers;

public class TagsController : Controller
{
    private readonly ITagAppService _tagAppService;

    public TagsController(ITagAppService tagAppService)
    {
        _tagAppService = tagAppService;
    }

    // GET: Tags
    public async Task<IActionResult> Index()
    {
        var tags = await _tagAppService.GetAllTagsAsync();
        return View(tags);
    }

    // GET: Tags/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Tags/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TagViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var command = new CreateTagCommand { Descricao = viewModel.Descricao };
            await _tagAppService.CreateTagAsync(command);
            return RedirectToAction(nameof(Index));
        }
        return View(viewModel);
    }

    // GET: Tags/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var tagDto = await _tagAppService.GetTagByIdAsync(id);
        if (tagDto == null)
        {
            return NotFound();
        }
        var viewModel = new TagViewModel { Id = tagDto.Id, Descricao = tagDto.Descricao };
        return View(viewModel);
    }

    // POST: Tags/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TagViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var command = new UpdateTagCommand { Id = viewModel.Id, Descricao = viewModel.Descricao };
            await _tagAppService.UpdateTagAsync(command);
            return RedirectToAction(nameof(Index));
        }
        return View(viewModel);
    }

    // GET: Tags/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var tagDto = await _tagAppService.GetTagByIdAsync(id);
        if (tagDto == null)
        {
            return NotFound();
        }
        return View(tagDto);
    }

    // POST: Tags/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _tagAppService.DeleteTagAsync(id);
        return RedirectToAction(nameof(Index));
    }
}