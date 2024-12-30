using MediaVisualizer.DataMigrator.Seeds;

namespace MediaVisualizer.Services;

public class SeedsMigratorService : ISeedMigratorService
{
    private readonly ISeedsMigrator _seedsMigrator;

    public SeedsMigratorService(ISeedsMigrator seedsMigrator)
    {
        _seedsMigrator = seedsMigrator;
    }

    public async Task Migrate()
    {
        await _seedsMigrator.Migrate();
    }
}

public interface ISeedMigratorService
{
    public Task Migrate();
}