using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;
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

        var totalCount = await query.CountAsync();

        if (filters.SortOrder != null)
        {
            query = filters.SortOrder switch
            {
                "asc" => query.OrderBy(x => x.Title),
                "desc" => query.OrderByDescending(x => x.Title),
                _ => query
            };
        }

        if (filters.BrandIds != null && filters.BrandIds.Count != 0)
            query = query.Where(x => x.Brands.Any(y => filters.BrandIds.Contains(y.BrandId)));

        if (filters.TagIds != null && filters.TagIds.Count != 0)
            query = query.Where(x => x.Tags.Any(y => filters.TagIds.Contains(y.TagId)));

        if (filters.ArtistIds != null && filters.ArtistIds.Count != 0)
            query = query.Where(x => x.Artists.Any(y => filters.ArtistIds.Contains(y.ArtistId)));

        if (filters.AuthorIds != null && filters.AuthorIds.Count != 0)
            query = query.Where(x => x.Authors.Any(y => filters.AuthorIds.Contains(y.AuthorId)));

        if (filters.Page != null && filters.Page > 0 && filters.Size != null && filters.Size > 0)
            query = query.Skip(filters.Size.Value * (filters.Page.Value - 1)).Take(filters.Size.Value);

        var mangas = await query.ToListAsync();

        return (totalCount, mangas);
    }

    public async Task<Manga> Get(int mangaKey)
    {
        var query = GetBaseQuery();
        return await query.FirstAsync(x => x.MangaId == mangaKey);
    }

    public async Task<Manga> GetRandom()
    {
        var query = GetBaseQuery();
        var count = await _context.Mangas.CountAsync();
        var randomIndex = new Random().Next(count);
        return await query.Skip(randomIndex).FirstAsync();
    }

    private IQueryable<Manga> GetBaseQuery()
    {
        return _context.Mangas
            .Include(x => x.MangaChapters)
            .Include(x => x.Brands)
            .Include(x => x.Tags)
            .Include(x => x.Artists)
            .Include(x => x.Authors);
    }
}

public interface IMangaRepository
{
    public Task<(int totalCount, IEnumerable<Manga>)> GetList(FiltersRequest filters);
    public Task<Manga> Get(int mangaKey);
    public Task<Manga> GetRandom();
}