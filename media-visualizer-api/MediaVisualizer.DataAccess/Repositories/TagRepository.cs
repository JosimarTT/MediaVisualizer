using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class TagRepository:ITagRepository
{
    private readonly MediaVisualizerDbContext _dbContext;

    public TagRepository(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Tag>> GetList()
    {
        return await _dbContext.Tags.ToListAsync();
    }

    
}

public interface ITagRepository
{
    public Task< IEnumerable<Tag>> GetList();
}