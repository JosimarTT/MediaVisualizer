using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.DataImporter;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services;

public class TagService:ITagService
{
    private readonly ITagRepository _tagRepository;
    private readonly ITagImporter _tagImporter;

    public TagService(ITagRepository tagRepository, ITagImporter tagImporter)
    {
        _tagRepository = tagRepository;
        _tagImporter = tagImporter;
    }

    public async Task<ICollection<TagDto>> GetList()
    {
        var artists = await _tagRepository.GetList();
        return artists.ToList().ToListDto();
    }

    public async Task ImportData()
    {
        await _tagImporter.ImportData();
    }
}

public interface ITagService
{
    Task<ICollection<TagDto>> GetList();
    Task ImportData();
}