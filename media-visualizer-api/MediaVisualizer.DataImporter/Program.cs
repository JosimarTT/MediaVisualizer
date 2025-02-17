using System;
using System.Threading.Tasks;
using MediaVisualizer.DataAccess;
using MediaVisualizer.DataImporter.Importers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MediaVisualizer.DataImporter
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            Console.WriteLine("Starting Tags import...");
            var tagImporter = serviceProvider.GetRequiredService<TagImporter>();
            await tagImporter.ImportData();
            Console.WriteLine("Tags data import completed.");

            Console.WriteLine("Starting Brands import...");
            var brandImporter = serviceProvider.GetRequiredService<BrandImporter>();
            await brandImporter.ImportData();
            Console.WriteLine("Brands data import completed.");


            Console.WriteLine("Starting Anime import...");
            var animeImporter = serviceProvider.GetRequiredService<AnimeImporter>();
            await animeImporter.ImportData();
            Console.WriteLine("Anime data import completed.");

            Console.WriteLine("Starting Manga import...");
            var mangaImporter = serviceProvider.GetRequiredService<MangaImporter>();
            await mangaImporter.ImportData();
            Console.WriteLine("Manga data import completed.");

            Console.WriteLine("Starting Manwha import...");
            var manwhaImporter = serviceProvider.GetRequiredService<ManwhaImporter>();
            await manwhaImporter.ImportData();
            Console.WriteLine("Manwha data import completed.");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MediaVisualizerDbContext>(options =>
            {
                options.UseSqlite(
                    "Data Source=E:\\media-visualizer\\media-visualizer-api\\MediaVisualizer.DataAccess\\media-visualizer.db");
            });

            // Register your TagImporter
            services.AddTransient<AnimeImporter>();
            services.AddTransient<MangaImporter>();
            services.AddTransient<ManwhaImporter>();
            services.AddTransient<TagImporter>();
            services.AddTransient<BrandImporter>();
        }
    }
}