using MediaVisualizer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly MediaVisualizerDbContext _context;

    public BrandRepository(MediaVisualizerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Brand>> GetList()
    {
        return await _context.Brands
            .OrderBy(x => x.Name)
            .ToListAsync();
    }
}

public interface IBrandRepository
{
    public Task<IEnumerable<Brand>> GetList();
}