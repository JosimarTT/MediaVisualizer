using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Seeds;

public class DbSeeds
{
    private readonly MediaVisualizerDbContext _context;

    public DbSeeds(MediaVisualizerDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        var scriptDirectory = Path.Combine(Directory.GetCurrentDirectory());
        var scriptFiles = Directory.GetFiles(scriptDirectory, "*.sql")
            .OrderBy(f => f)
            .ToArray();

        foreach (var scriptFile in scriptFiles)
        {
            var script = File.ReadAllText(scriptFile);
            _context.Database.ExecuteSqlRaw(script);
        }
    }
}