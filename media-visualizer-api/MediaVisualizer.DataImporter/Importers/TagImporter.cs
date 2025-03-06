using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities;
using MediaVisualizer.DataImporter.Models;
using MediaVisualizer.Shared;
using YamlDotNet.Serialization;

namespace MediaVisualizer.DataImporter.Importers;

public class TagImporter
{
    private readonly MediaVisualizerDbContext _context;
    private readonly string basePath = Path.Combine(Constants.BaseCollectionPath, Constants.MangaFolderPath);

    public TagImporter(MediaVisualizerDbContext context)
    {
        _context = context;
    }

    public async Task ImportData()
    {
        if (_context.Tags.Any()) return;

        var tags = new List<Tag>();

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

                        foreach (var tagName in info.Tags)
                            if (!tags.Any(t => t.Name.ToLower() == tagName.ToLower()))
                                tags.Add(new Tag { Name = tagName });

                        foreach (var tagName in info.General)
                            if (!tags.Any(t => t.Name.ToLower() == tagName.ToLower()))
                                tags.Add(new Tag { Name = tagName });
                    }
                }
            }
        }

        try
        {
            await _context.Database.BeginTransactionAsync();
            await _context.Tags.AddRangeAsync(tags);
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