using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.DataImporter;
using MediaVisualizer.DataImporter.Importers;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;

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

    public async Task<ListResponse<MangaDto>> GetList(FiltersRequest filters)
    {
        var (totalCount, mangas) = await _mangaRepository.GetList(filters);
        var mangaListDto = mangas.ToList().ToListDto();
        return new ListResponse<MangaDto>(mangaListDto, totalCount, filters.Size!.Value, filters.Page!.Value);
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
    public Task<ListResponse<MangaDto>> GetList(FiltersRequest filters);
    public Task<MangaDto> GetRandom();
}