using MediaVisualizer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly MediaVisualizerDbContext _context;

    public AuthorRepository(MediaVisualizerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> GetList()
    {
        return await _context.Authors.ToListAsync();
    }
}

public interface IAuthorRepository
{
    public Task<IEnumerable<Author>> GetList();
}