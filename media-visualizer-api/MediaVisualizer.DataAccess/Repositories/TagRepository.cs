using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class TagRepository : ITagRepository
{
    private readonly MediaVisualizerDbContext _context;

    public TagRepository(MediaVisualizerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tag>> GetList()
    {
         return await _context.Tags.ToListAsync();
    }
}

public interface ITagRepository
{
    public Task<IEnumerable<Tag>> GetList();
}