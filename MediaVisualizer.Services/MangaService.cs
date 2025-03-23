using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;

namespace MediaVisualizer.Services;

public class MangaService : IMangaService
{
    private readonly IMangaRepository _mangaRepository;

    public MangaService(IMangaRepository mangaRepository)
    {
        _mangaRepository = mangaRepository;
    }

    public async Task<MangaDto> Get(int mangaId)
    {
        var manga = await _mangaRepository.Get(mangaId);
        return manga.ToDto();
    }

    public async Task<ListResponse<MangaDto>> GetList(FiltersRequest filters)
    {
        var (totalCount, mangas) = await _mangaRepository.GetList(filters);
        var mangaListDto = mangas.ToList().ToListDto();
        return new ListResponse<MangaDto>(mangaListDto, totalCount, filters.Size!.Value, filters.Page!.Value);
    }

    public async Task<MangaDto> GetRandom()
    {
        var manga = await _mangaRepository.GetRandom();
        return manga.ToDto();
    }

    public Task<string[]> GetTitlesToAdd()
    {
        var files = Directory.GetFiles(Constants.MangaDownloadPath, "*.cbz");
        return Task.FromResult(files);
    }

    public Task<List<string>> GetTitles()
    {
        return _mangaRepository.GetTitles();
    }

    public Task<MangaDto> Add(MangaDto manga)
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetMangaPage(MangaDto mangaDto, int pageNumber)
    {
        var mangaPath = Path.Combine(Constants.MangaCollectionPath, mangaDto.Folder);

        if (!Directory.Exists(mangaPath))
            throw new DirectoryNotFoundException($"Manga with title '{mangaDto.Title}' not found.");

        var fileName = Path.Combine(mangaPath, $"{pageNumber:D3}{mangaDto.PageExtension}");
        if (File.Exists(fileName))
        {
            var fileBytes = await File.ReadAllBytesAsync(fileName);
            var base64String = Convert.ToBase64String(fileBytes);
            return $"data:image/jpeg;base64,{base64String}";
        }

        throw new FileNotFoundException($"Page {pageNumber} not found.");
    }
}

public interface IMangaService
{
    public Task<MangaDto> Get(int mangaId);
    public Task<ListResponse<MangaDto>> GetList(FiltersRequest filters);
    public Task<MangaDto> GetRandom();
    Task<string[]> GetTitlesToAdd();
    Task<List<string>> GetTitles();
    Task<MangaDto> Add(MangaDto manga);
    Task<string> GetMangaPage(MangaDto mangaDto, int pageNumber);
}