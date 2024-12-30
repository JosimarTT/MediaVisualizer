using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;

namespace MediaVisualizer.Services;

public class MangaService : IMangaService
{
    private readonly IMangaRepository _mangaRepository;

    public MangaService(IMangaRepository mangaRepository)
    {
        _mangaRepository = mangaRepository;
    }

    public async Task<MangaDto> Get(int key)
    {
        var manga = await _mangaRepository.Get(key);
        return manga.ToDto();
    }

    public async Task<IEnumerable<MangaDto>> GetList(FiltersRequest filters)
    {
        var mangas = await _mangaRepository.GetList(filters);
        return mangas.ToList().ToListDto();
    }

    public async Task<MangaDto> GetRandom()
    {
        var manga = await _mangaRepository.GetRandom();
        return manga.ToDto();
    }
}

public interface IMangaService
{
    public Task<MangaDto> Get(int key);
    public Task<IEnumerable<MangaDto>> GetList(FiltersRequest filters);
    public Task<MangaDto> GetRandom();
}