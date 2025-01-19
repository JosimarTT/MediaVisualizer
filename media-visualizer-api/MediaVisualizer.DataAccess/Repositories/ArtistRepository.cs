using MediaVisualizer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class ArtistRepository : IArtistRepository
{
    private readonly MediaVisualizerDbContext _context;

    public ArtistRepository(MediaVisualizerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Artist>> GetList()
    {
        return await _context.Artists.ToListAsync();
    }
}

public interface IArtistRepository
{
    public Task<IEnumerable<Artist>> GetList();
}