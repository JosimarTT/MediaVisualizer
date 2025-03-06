using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities;
using MediaVisualizer.DataImporter.Models;
using MediaVisualizer.Shared;
using YamlDotNet.Serialization;

namespace MediaVisualizer.DataImporter.Importers;

public class BrandImporter
{
    private readonly MediaVisualizerDbContext _context;
    private readonly string basePath = Path.Combine(Constants.BaseCollectionPath, Constants.MangaFolderPath);

    public BrandImporter(MediaVisualizerDbContext context)
    {
        _context = context;
    }

    public async Task ImportData()
    {
        if (_context.Brands.Any()) return;

        var brands = new List<Brand>();

        foreach (var folder in Constants.MangaFolders)
        {
            var folderPath = Path.Combine(basePath, folder);
            if (Directory.Exists(folderPath))
            {
                var subfolders = Directory.GetDirectories(folderPath);
                foreach (var subfolder in subfolders)
                {
                    var infoFilePath = Path.Combine(subfolder, "info.yaml");
                    if (File.Exists(infoFilePath))
                    {
                        var deserializer = new DeserializerBuilder()
                            .IgnoreUnmatchedProperties()
                            .WithCaseInsensitivePropertyMatching()
                            .Build();

                        var yamlContent = await File.ReadAllTextAsync(infoFilePath);
                        var info = deserializer.Deserialize<InfoYaml>(yamlContent);

                        foreach (var brandName in info.Tags)
                            if (!brands.Any(t => t.Name.ToLower() == brandName.ToLower()))
                                brands.Add(new Brand { Name = brandName });

                        foreach (var brandName in info.General)
                            if (!brands.Any(t => t.Name.ToLower() == brandName.ToLower()))
                                brands.Add(new Brand { Name = brandName });
                    }
                }
            }
        }

        try
        {
            await _context.Database.BeginTransactionAsync();
            await _context.Brands.AddRangeAsync(brands);
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
        }
        catch
        {
            await _context.Database.RollbackTransactionAsync();
            throw;
        }
    }
}