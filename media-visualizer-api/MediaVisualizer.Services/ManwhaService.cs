using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;

namespace MediaVisualizer.Services;

public class ManwhaService : IManwhaService
{
    private readonly IManwhaRepository _manwhaRepository;

    public ManwhaService(IManwhaRepository manwhaRepository)
    {
        _manwhaRepository = manwhaRepository;
    }

    public async Task<ManwhaDto> Get(int key)
    {
        var manwha = await _manwhaRepository.Get(key);
        return manwha.ToDto();
    }

    public async Task<IEnumerable<ManwhaDto>> GetList(FiltersRequest filters)
    {
        var manwhas = await _manwhaRepository.GetList(filters);
        return manwhas.ToList().ToListDto();
    }

    public async Task<ManwhaDto> GetRandom()
    {
        var manwha = await _manwhaRepository.GetRandom();
        return manwha.ToDto();
    }
}

public interface IManwhaService
{
    public Task<ManwhaDto> Get(int key);
    public Task<IEnumerable<ManwhaDto>> GetList(FiltersRequest filters);
    public Task<ManwhaDto> GetRandom();
}