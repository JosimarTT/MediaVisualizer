using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _artistRepository;

    public BrandService(IBrandRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<ICollection<BrandDto>> GetList()
    {
        var artists = await _artistRepository.GetList();
        return artists.ToList().ToListDto();
    }
}

public interface IBrandService
{
    Task<ICollection<BrandDto>> GetList();
}