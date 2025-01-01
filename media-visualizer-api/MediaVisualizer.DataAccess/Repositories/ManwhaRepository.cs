using MediaVisualizer.DataAccess.Entities.Manwha;
using MediaVisualizer.Shared.Requests;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class ManwhaRepository : IManwhaRepository
{
    private readonly MediaVisualizerDbContext _dbContext;

    public ManwhaRepository(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(int totalCount, IEnumerable<Manwha>)> GetList(FiltersRequest filters)
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

        var manwhas = await query.ToListAsync();

        return (totalCount, manwhas);
    }

    public async Task<Manwha> GetRandom()
    {
        var query = GetBaseQuery();
        var count = await _dbContext.Manwhas.CountAsync();
        var randomIndex = new Random().Next(count);
        return await query.Skip(randomIndex).FirstAsync();
    }

    public async Task<Manwha> Get(int manwhaKey)
    {
        var query = GetBaseQuery();
        return await query.FirstAsync(x => x.ManwhaId == manwhaKey);
    }

    private IQueryable<Manwha> GetBaseQuery()
    {
        return _dbContext.Manwhas
            .Include(x => x.ManwhaChapters)
            .Include(x => x.Brands)
            .Include(x => x.Tags)
            .Include(x => x.Artists)
            .Include(x => x.Authors);
    }
}

public interface IManwhaRepository
{
    public Task<Manwha> Get(int manwhaKey);
    public Task<(int totalCount, IEnumerable<Manwha>)> GetList(FiltersRequest filters);
    public Task<Manwha> GetRandom();
}