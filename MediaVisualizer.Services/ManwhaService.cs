using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;

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

    public async Task<ListResponse<ManwhaDto>> GetList(FiltersRequest filters)
    {
        var (totalCount, manwhas) = await _manwhaRepository.GetList(filters);
        var manwhaListDto = manwhas.ToList().ToListDto();
        return new ListResponse<ManwhaDto>(manwhaListDto, totalCount, filters.Size!.Value, filters.Page!.Value);
    }

    public async Task<ManwhaDto> GetRandom()
    {
        var manwha = await _manwhaRepository.GetRandom();
        return manwha.ToDto();
    }

    public Task<List<string>> GetTitles()
    {
        return _manwhaRepository.GetTitles();
    }
}

public interface IManwhaService
{
    public Task<ManwhaDto> Get(int key);
    public Task<ListResponse<ManwhaDto>> GetList(FiltersRequest filters);
    public Task<ManwhaDto> GetRandom();
    Task<List<string>> GetTitles();
}