using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.DataImporter;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;

namespace MediaVisualizer.Services;

public class ManwhaService : IManwhaService
{
    private readonly IManwhaRepository _manwhaRepository;
    private readonly IManwhaImporterRepository _manwhaImporterRepository;

    public ManwhaService(IManwhaRepository manwhaRepository, IManwhaImporterRepository manwhaImporterRepository)
    {
        _manwhaRepository = manwhaRepository;
        _manwhaImporterRepository = manwhaImporterRepository;
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

    public async Task Migrate()
    {
        await _manwhaImporterRepository.Migrate();
    }
}

public interface IManwhaService
{
    public Task<ManwhaDto> Get(int key);
    public Task<ListResponse<ManwhaDto>> GetList(FiltersRequest filters);
    public Task<ManwhaDto> GetRandom();
    public Task Migrate();
}