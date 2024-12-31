using MediaVisualizer.DataMigrator;

namespace MediaVisualizer.Services;

public class SeedsMigratorService : ISeedMigratorService
{
    private readonly ISeedsMigratorRepository _seedsMigratorRepository;

    public SeedsMigratorService(ISeedsMigratorRepository seedsMigratorRepository)
    {
        _seedsMigratorRepository = seedsMigratorRepository;
    }

    public async Task Migrate()
    {
        await _seedsMigratorRepository.Migrate();
    }
}

public interface ISeedMigratorService
{
    public Task Migrate();
}