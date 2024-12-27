using System.Linq.Expressions;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.Shared.Requests;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class AnimeRepository : IAnimeRepository
{
    private readonly MediaVisualizerDbContext _dbContext;

    public AnimeRepository(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Anime>> GetList(FiltersRequest filters)
    {
        var query = _dbContext.Anime
            .Include(x => x.Brands)
            .Include(x => x.Tags)
            .AsQueryable();

        if (filters == null)
            return await query.ToListAsync();

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
            query = query.Where(x => x.Brands.Any(y => filters.BrandKeys.Contains(y.BrandKey)));

        if (filters.TagKeys != null && filters.TagKeys.Count != 0)
            query = query.Where(x => x.Tags.Any(y => filters.TagKeys.Contains(y.TagKey)));

        if (filters.Page != null && filters.Page > 0 && filters.Size != null && filters.Size > 0)
            query = query.Skip(filters.Size.Value * filters.Page.Value).Take(filters.Size.Value);

        return await query.ToListAsync();
    }

    public async Task<Anime> Get(int animeKey)
    {
        return await _dbContext.Anime
            .Include(x => x.Brands)
            .Include(x => x.Tags)
            .SingleOrDefaultAsync(x => x.AnimeKey == animeKey);
    }

    public async Task Create(Anime anime)
    {
        await _dbContext.AddAsync(anime);
    }

    public async Task Update(Anime anime)
    {
        _dbContext.Anime.Update(anime);
        await _dbContext.SaveChangesAsync();
    }
}

public interface IAnimeRepository
{
    public Task<IEnumerable<Anime>> GetList(FiltersRequest filters);
    public Task<Anime> Get(int animeKey);
    public Task Create(Anime anime);
    public Task Update(Anime anime);
}