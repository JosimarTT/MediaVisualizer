using MediaVisualizer.DataAccess.Entities.Anime;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Repositories;

public class AnimeRepository:IAnimeRepository
{
    private readonly MediaVisualizerDbContext _dbContext;

    public AnimeRepository(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Anime>> GetAll()
    {
        return await _dbContext.Anime
            .Include(x => x.Brands)
            .Include(x => x.Tags)
            .ToListAsync();
    }

    public async Task<Anime> Get(int animeKey)
    {
        return await _dbContext.Anime
            .Include(x => x.Brands)
            .Include(x => x.Tags)
            .SingleOrDefaultAsync(x => x.AnimeKey == animeKey);
    }

    public async Task Create(Anime anime)
    {
        await _dbContext.AddAsync(anime);
    }

  public async Task Update(Anime anime)
{
    _dbContext.Anime.Update(anime);
    await _dbContext.SaveChangesAsync();
}
}

public interface IAnimeRepository
{
    public Task<IEnumerable<Anime>> GetAll();
    public Task<Anime> Get(int animeKey);
    public Task Create(Anime anime);
    public Task Update(Anime anime);
}