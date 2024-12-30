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

        if (filters.BrandKeys != null && filters.BrandKeys.Count != 0)
            query = query.Where(x => x.Brands.Any(y => filters.BrandKeys.Contains(y.BrandId)));

        if (filters.TagKeys != null && filters.TagKeys.Count != 0)
            query = query.Where(x => x.Tags.Any(y => filters.TagKeys.Contains(y.TagId)));

        if (filters.ArtistKeys != null && filters.ArtistKeys.Count != 0)
            query = query.Where(x => x.Artists.Any(y => filters.ArtistKeys.Contains(y.ArtistId)));

        if (filters.AuthorKeys != null && filters.AuthorKeys.Count != 0)
            query = query.Where(x => x.Authors.Any(y => filters.AuthorKeys.Contains(y.AuthorId)));

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