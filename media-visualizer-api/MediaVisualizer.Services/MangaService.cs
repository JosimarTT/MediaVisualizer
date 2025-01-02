using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.DataImporter;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;

namespace MediaVisualizer.Services;

public class MangaService : IMangaService
{
    private readonly IMangaRepository _mangaRepository;
    private readonly IMangaImporterRepository _mangaImporterRepository;

    public MangaService(IMangaRepository mangaRepository, IMangaImporterRepository mangaImporterRepository)
    {
        _mangaRepository = mangaRepository;
        _mangaImporterRepository = mangaImporterRepository;
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

    public async Task Migrate()
    {
         await _mangaImporterRepository.Migrate();
    }
}

public interface IMangaService
{
    public Task<MangaDto> Get(int key);
    public Task<ListResponse<MangaDto>> GetList(FiltersRequest filters);
    public Task<MangaDto> GetRandom();
    public Task Migrate();
}