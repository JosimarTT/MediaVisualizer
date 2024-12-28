using MediaVisualizer.DataMigrator.Seeds;

namespace MediaVisualizer.Services;

public class SeedsMigratorService : ISeedMigratorService
{
    private readonly ISeedsMigrator _seedsMigrator;

    public SeedsMigratorService(ISeedsMigrator seedsMigrator)
    {
        _seedsMigrator = seedsMigrator;
    }

    public void Migrate()
    {
        _seedsMigrator.Migrate();
    }
}

public interface ISeedMigratorService
{
    public void Migrate();
}