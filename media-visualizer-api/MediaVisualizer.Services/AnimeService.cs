using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;

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
        return anime.ConvertToAnimeDto();
    }

    public async Task<IEnumerable<AnimeDto>> GetList(FiltersRequest filters)
    {
        var animes = await _animeRepository.GetList(filters);
        return animes.ToList().ConvertToListDto();
    }
}

public interface IAnimeService
{
    public Task<AnimeDto> Get(int id);
    public Task<IEnumerable<AnimeDto>> GetList(FiltersRequest filters);
}