using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services;

public class AuthorService:IAuthorService
{
    private readonly IAuthorRepository _artistRepository;

    public AuthorService(IAuthorRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<ICollection<AuthorDto>> GetList()
    {
        var artists = await _artistRepository.GetList();
        return artists.ToList().ToListDto();
    }
}

public interface IAuthorService
{
    Task<ICollection<AuthorDto>> GetList();
}