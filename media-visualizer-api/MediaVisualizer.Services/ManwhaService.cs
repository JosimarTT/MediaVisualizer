using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.DataMigrator;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;

namespace MediaVisualizer.Services;

public class ManwhaService : IManwhaService
{
    private readonly IManwhaRepository _manwhaRepository;
    private readonly IManwhaMigratorRepository _manwhaMigratorRepository;

    public ManwhaService(IManwhaRepository manwhaRepository, IManwhaMigratorRepository manwhaMigratorRepository)
    {
        _manwhaRepository = manwhaRepository;
        _manwhaMigratorRepository = manwhaMigratorRepository;
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

    public async Task Migrate()
    {
        await _manwhaMigratorRepository.Migrate();
    }
}

public interface IManwhaService
{
    public Task<ManwhaDto> Get(int key);
    public Task<IEnumerable<ManwhaDto>> GetList(FiltersRequest filters);
    public Task<ManwhaDto> GetRandom();
    public Task Migrate();
}