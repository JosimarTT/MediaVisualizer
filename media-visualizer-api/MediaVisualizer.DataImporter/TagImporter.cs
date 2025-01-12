using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities.Shared;
using MediaVisualizer.Shared;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediaVisualizer.DataImporter.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace MediaVisualizer.DataImporter
{
    public class TagImporter : ITagImporter
    {
        private readonly MediaVisualizerDbContext _context;
        private readonly string basePath = Path.Combine(Constants.BaseCollectionFolderPath, Constants.MangaFolderPath);

        public TagImporter(MediaVisualizerDbContext context)
        {
            _context = context;
        }

        public async Task ImportData()
        {
            if (_context.Tags.Any())
            {
                return;
            }

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
                            Console.WriteLine(infoFilePath);
                            var info = deserializer.Deserialize<InfoYaml>(yamlContent);

                            foreach (var tagName in info.Tags)
                            {
                                if (!tags.Any(t => t.Name == tagName))
                                {
                                    tags.Add(new Tag { Name = tagName });
                                }
                            }

                            foreach (var tagName in info.General)
                            {
                                if (!tags.Any(t => t.Name == tagName))
                                {
                                    tags.Add(new Tag { Name = tagName });
                                }
                            }
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

    public interface ITagImporter
    {
        Task ImportData();
    }
}