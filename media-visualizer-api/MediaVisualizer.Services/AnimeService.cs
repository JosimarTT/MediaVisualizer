using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.Shared.Converters;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services;

public class AnimeService:IAnimeService
{
    private readonly IAnimeRepository _animeRepository;

    public AnimeService(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task Create(AnimeDto animeDto)
    {
        var anime = new Anime();
        await _animeRepository.Create(anime);
    }

    public async Task Update(AnimeDto animeDto)
    {
        throw new NotImplementedException();
    }

    public Task<AnimeDto> Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<AnimeDto>> GetAll()
    {
        var animes = await _animeRepository.GetAll();
        return animes.ToList().ConvertToListDto();
    }
}

public interface IAnimeService
{
    public Task Create(AnimeDto animeDto);
    public Task Update(AnimeDto animeDto);
    public Task<AnimeDto> Get(int id);
    public Task<IEnumerable<AnimeDto>> GetAll();
}