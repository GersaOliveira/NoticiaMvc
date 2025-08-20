using TagMvc.Application.Tags.Commands;
using TagMvc.Application.Tags.Dtos;

namespace TagMvc.Application.Interfaces;

public interface ITagAppService
{
    Task<IEnumerable<TagDto>> GetAllTagsAsync();
    Task<TagDto?> GetTagByIdAsync(int id);
    Task CreateTagAsync(CreateTagCommand command);
    Task UpdateTagAsync(UpdateTagCommand command);
    Task DeleteTagAsync(int id);
}