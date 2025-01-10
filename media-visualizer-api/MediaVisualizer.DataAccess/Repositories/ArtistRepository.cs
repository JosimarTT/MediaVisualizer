using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class ArtistRepository:IArtistRepository
{
    private readonly MediaVisualizerDbContext _dbContext;

    public ArtistRepository(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Artist>> GetList()
    {
        return await _dbContext.Artists.ToListAsync();
    }

    
}

public interface IArtistRepository
{
    public Task< IEnumerable<Artist>> GetList();
}