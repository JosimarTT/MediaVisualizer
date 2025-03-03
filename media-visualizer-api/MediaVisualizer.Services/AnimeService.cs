using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.DataImporter;
using MediaVisualizer.DataImporter.Importers;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;

namespace MediaVisualizer.Services;

public class AnimeService : IAnimeService
{
    private readonly IAnimeRepository _animeRepository;

    public AnimeService(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
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
}

public interface IAnimeService
{
    public Task<AnimeDto> Get(int key);
    public Task<ListResponse<AnimeDto>> GetList(FiltersRequest filters);
    Task<AnimeDto> GetRandom();
}