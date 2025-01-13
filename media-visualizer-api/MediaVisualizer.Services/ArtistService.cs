using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services;

public class ArtistService : IArtistService
{
    private readonly IArtistRepository _artistRepository;

    public ArtistService(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<ICollection<ArtistDto>> GetList()
    {
        var artists = await _artistRepository.GetList();
        return artists.ToList().ToListDto();
    }
}

public interface IArtistService
{
    Task<ICollection<ArtistDto>> GetList();
}