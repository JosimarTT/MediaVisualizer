using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.DataImporter;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;

namespace MediaVisualizer.Services;

public class AnimeService : IAnimeService
{
    private readonly IAnimeRepository _animeRepository;
    private readonly IAnimeImporterRepository _animeImporterRepository;

    public AnimeService(IAnimeRepository animeRepository, IAnimeImporterRepository animeImporterRepository)
    {
        _animeRepository = animeRepository;
        _animeImporterRepository = animeImporterRepository;
    }

    public async Task<AnimeDto> Get(int key)
    {
        var anime = await _animeRepository.Get(key);
        return anime.ToDto();
    }

    public async Task<ListResponse<AnimeDto>> GetList(FiltersRequest filters)
    {
        var (totalCount, animes) = await _animeRepository.GetList(filters);
        var animeListDto = animes.ToList().ToListDto();
        return new ListResponse<AnimeDto>(animeListDto, totalCount, filters.Size!.Value, filters.Page!.Value);
    }

    public async Task<AnimeDto> GetRandom()
    {
        var anime = await _animeRepository.GetRandom();
        return anime.ToDto();
    }

    public async Task Migrate()
    {
        await _animeImporterRepository.Migrate();
    }
}

public interface IAnimeService
{
    public Task<AnimeDto> Get(int key);
    public Task<ListResponse<AnimeDto>> GetList(FiltersRequest filters);
    Task<AnimeDto> GetRandom();
    Task Migrate();
}