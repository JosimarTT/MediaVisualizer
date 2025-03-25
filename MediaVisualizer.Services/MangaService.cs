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
        return await manga.ToDto();
    }

    public async Task<ListResponse<MangaDto>> GetList(FiltersRequest filters)
    {
        var (totalCount, mangas) = await _mangaRepository.GetList(filters);
        var mangaListDto = await mangas.ToList().ToListDto(filters.Percentage!.Value);
        return new ListResponse<MangaDto>(mangaListDto, totalCount, filters.Size!.Value, filters.Page!.Value);
    }

    public async Task<string> GetRandom()
    {
        var manga = await _mangaRepository.GetRandom();

        var mangaPath = Path.Combine(StringConstants.MangaCollectionPath, manga.Folder);

        if (!Directory.Exists(mangaPath))
            throw new DirectoryNotFoundException($"Manga with title '{manga.Title}' not found.");

        var fileName = Path.Combine(mangaPath, $"001{manga.PageExtension}");
        if (File.Exists(fileName))
        {
            var fileBytes = await File.ReadAllBytesAsync(fileName);
            var base64String = Convert.ToBase64String(fileBytes);
            return $"data:image/jpeg;base64,{base64String}";
        }

        throw new FileNotFoundException("Manga logo not found.");
    }

    public Task<string[]> GetTitlesToAdd()
    {
        var files = Directory.GetFiles(StringConstants.MangaDownloadPath, "*.cbz");
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
        var mangaPath = Path.Combine(StringConstants.MangaCollectionPath, mangaDto.Folder);

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
    public Task<string> GetRandom();
    Task<string[]> GetTitlesToAdd();
    Task<List<string>> GetTitles();
    Task<MangaDto> Add(MangaDto manga);
    Task<string> GetMangaPage(MangaDto mangaDto, int pageNumber);
}