using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class AuthorRepository:IAuthorRepository
{
    private readonly MediaVisualizerDbContext _dbContext;

    public AuthorRepository(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Author>> GetList()
    {
        return await _dbContext.Authors.ToListAsync();
    }

    
}

public interface IAuthorRepository
{
    public Task< IEnumerable<Author>> GetList();
}