using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services;

public class TagService:ITagService
{
    private readonly ITagRepository _artistRepository;

    public TagService(ITagRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<ICollection<TagDto>> GetList()
    {
        var artists = await _artistRepository.GetList();
        return artists.ToList().ToListDto();
    }
}

public interface ITagService
{
    Task<ICollection<TagDto>> GetList();
}