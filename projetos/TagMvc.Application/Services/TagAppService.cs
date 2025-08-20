using TagMvc.Application.Interfaces;
using TagMvc.Application.Tags.Commands;
using TagMvc.Application.Tags.Dtos;
using TagMvc.Domain.Entities;
using TagMvc.Domain.Interfaces;

namespace TagMvc.Application.Services;

public class TagAppService : ITagAppService
{
    private readonly ITagRepository _tagRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TagAppService(ITagRepository tagRepository, IUnitOfWork unitOfWork)
    {
        _tagRepository = tagRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TagDto>> GetAllTagsAsync()
    {
        var tags = await _tagRepository.GetAllAsync();
        // Em um projeto real, use uma biblioteca como o AutoMapper para isso.
        return tags.Select(t => new TagDto { Id = t.Id, Descricao = t.Descricao });
    }

    public async Task<TagDto?> GetTagByIdAsync(int id)
    {
        var tag = await _tagRepository.GetByIdAsync(id);
        if (tag is null) return null;
        return new TagDto { Id = tag.Id, Descricao = tag.Descricao };
    }

    public async Task CreateTagAsync(CreateTagCommand command)
    {
        var tag = new Tag { Descricao = command.Descricao };
        await _tagRepository.AddAsync(tag);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateTagAsync(UpdateTagCommand command)
    {
        var tag = await _tagRepository.GetByIdAsync(command.Id);
        if (tag is null)
        {
            // Lançar uma exceção ou tratar o caso de não encontrar a tag
            return;
        }

        tag.Descricao = command.Descricao;
        _tagRepository.Update(tag);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteTagAsync(int id)
    {
        var tag = await _tagRepository.GetByIdAsync(id);
        if (tag is not null)
        {
            _tagRepository.Remove(tag);
            await _unitOfWork.CommitAsync();
        }
    }
}