using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class TagRepository : ITagRepository
{
    private readonly MediaVisualizerDbContext _dbContext;

    public TagRepository(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Tag>> GetList()
    {
        // return await _dbContext.Tags.ToListAsync();
        var tags = new List<Tag>
        {
            new Tag { TagId = 1, Name = "Action" },
            new Tag { TagId = 2, Name = "Adventure" },
            new Tag { TagId = 3, Name = "Comedy" }
        };

        return await Task.FromResult<IEnumerable<Tag>>(tags);
    }
}

public interface ITagRepository
{
    public Task<IEnumerable<Tag>> GetList();
}