using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class BrandRepository:IBrandRepository
{
    private readonly MediaVisualizerDbContext _dbContext;

    public BrandRepository(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Brand>> GetList()
    {
        return await _dbContext.Brands.ToListAsync();
    }

    
}

public interface IBrandRepository
{
    public Task< IEnumerable<Brand>> GetList();
}