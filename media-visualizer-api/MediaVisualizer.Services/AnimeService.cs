using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.DataMigrator;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;

namespace MediaVisualizer.Services;

public class AnimeService : IAnimeService
{
    private readonly IAnimeRepository _animeRepository;
    private readonly IAnimeMigratorRepository _animeMigratorRepository;

    public AnimeService(IAnimeRepository animeRepository, IAnimeMigratorRepository animeMigratorRepository)
    {
        _animeRepository = animeRepository;
        _animeMigratorRepository = animeMigratorRepository;
    }

    public async Task<AnimeDto> Get(int key)
    {
        var anime = await _animeRepository.Get(key);
        return anime.ToDto();
    }

    public async Task<IEnumerable<AnimeDto>> GetList(FiltersRequest filters)
    {
        var animes = await _animeRepository.GetList(filters);
        return animes.ToList().ToListDto();
    }

    public async Task<AnimeDto> GetRandom()
    {
        var anime = await _animeRepository.GetRandom();
        return anime.ToDto();
    }

    public async Task Migrate()
    {
        await _animeMigratorRepository.Migrate();
    }
}

public interface IAnimeService
{
    public Task<AnimeDto> Get(int key);
    public Task<IEnumerable<AnimeDto>> GetList(FiltersRequest filters);
    Task<AnimeDto> GetRandom();
    Task Migrate();
}