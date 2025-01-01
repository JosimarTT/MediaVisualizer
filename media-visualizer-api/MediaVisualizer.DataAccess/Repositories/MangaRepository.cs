using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.Shared.Requests;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class MangaRepository : IMangaRepository
{
    private readonly MediaVisualizerDbContext _dbContext;

    public MangaRepository(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Manga>> GetList(FiltersRequest filters)
    {
        var query = GetBaseQuery();

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

        return await query.ToListAsync();
    }

    public async Task<Manga> Get(int mangaKey)
    {
        var query = GetBaseQuery();
        return await query.FirstAsync(x => x.MangaId == mangaKey);
    }

    public async Task<Manga> GetRandom()
    {
        var query = GetBaseQuery();
        var count = await _dbContext.Mangas.CountAsync();
        var randomIndex = new Random().Next(count);
        return await query.Skip(randomIndex).FirstAsync();
    }

    private IQueryable<Manga> GetBaseQuery()
    {
        return _dbContext.Mangas
            .Include(x => x.MangaChapters)
            .Include(x => x.Brands)
            .Include(x => x.Tags)
            .Include(x => x.Artists)
            .Include(x => x.Authors);
    }
}

public interface IMangaRepository
{
    public Task<IEnumerable<Manga>> GetList(FiltersRequest filters);
    public Task<Manga> Get(int mangaKey);
    public Task<Manga> GetRandom();
}