using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.Shared.Requests;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class MangaRepository : IMangaRepository
{
    private readonly MediaVisualizerDbContext _context;

    public MangaRepository(MediaVisualizerDbContext context)
    {
        _context = context;
    }

    public async Task<(int totalCount, IEnumerable<Manga>)> GetList(FiltersRequest filters)
    {
        var query = GetBaseQuery();

        if (filters.TagIds != null && filters.TagIds.Count != 0)
            query = query.Where(x => x.MangaTags.Any(y => filters.TagIds.Contains(y.TagId)));

        if (filters.ArtistIds != null && filters.ArtistIds.Count != 0)
            query = query.Where(x => x.MangaArtists.Any(y => filters.ArtistIds.Contains(y.ArtistId)));

        if (!string.IsNullOrWhiteSpace(filters.Title))
            query = query.Where(x => x.Title.ToLower().Contains(filters.Title.ToLower()));

        var totalCount = await query.CountAsync();

        if (filters.Page != null && filters.Page > 0 && filters.Size != null && filters.Size > 0)
            query = query.Skip(filters.Size.Value * (filters.Page.Value - 1)).Take(filters.Size.Value);

        var mangas = await query.ToListAsync();

        return (totalCount, mangas);
    }

    public async Task<Manga> Get(int mangaId)
    {
        var query = GetBaseQuery();
        return await query.FirstAsync(x => x.MangaId == mangaId);
    }

    public async Task<Manga> GetRandom()
    {
        var query = GetBaseQuery();
        var count = await _context.Mangas.CountAsync();
        var randomIndex = new Random().Next(count);
        return await query.Skip(randomIndex).FirstAsync();
    }

    public Task<List<string>> GetTitles()
    {
        return _context.Mangas
            .Select(x => x.Title)
            .OrderBy(x => x)
            .ToListAsync();
    }

    private IQueryable<Manga> GetBaseQuery()
    {
        return _context.Mangas
            .Include(x => x.MangaTags).ThenInclude(y => y.Tag)
            .Include(x => x.MangaArtists).ThenInclude(y => y.Artist)
            .OrderBy(x => x.Title)
            .ThenBy(x => x.ChapterNumber);
    }
}

public interface IMangaRepository
{
    public Task<(int totalCount, IEnumerable<Manga>)> GetList(FiltersRequest filters);
    public Task<Manga> Get(int mangaId);
    public Task<Manga> GetRandom();
    Task<List<string>> GetTitles();
}