using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.DataImporter;
using MediaVisualizer.DataImporter.Importers;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<ICollection<TagDto>> GetList()
    {
        var artists = await _tagRepository.GetList();
        return artists.ToList().ToListDto();
    }
}

public interface ITagService
{
    Task<ICollection<TagDto>> GetList();
}