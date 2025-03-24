using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Shared;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;

namespace MediaVisualizer.Services;

public class ManwhaService : IManwhaService
{
    private readonly IManwhaRepository _manwhaRepository;

    public ManwhaService(IManwhaRepository manwhaRepository)
    {
        _manwhaRepository = manwhaRepository;
    }

    public async Task<ManwhaDto> Get(int key)
    {
        var manwha = await _manwhaRepository.Get(key);
        return manwha.ToDto();
    }

    public async Task<ListResponse<ManwhaDto>> GetList(FiltersRequest filters)
    {
        var (totalCount, manwhas) = await _manwhaRepository.GetList(filters);
        var manwhaListDto = manwhas.ToList().ToListDto();
        return new ListResponse<ManwhaDto>(manwhaListDto, totalCount, filters.Size!.Value, filters.Page!.Value);
    }

    public async Task<string> GetRandom()
    {
        var manwha = await _manwhaRepository.GetRandom();

        var mangaPath = Path.Combine(Constants.ManwhaCollectionPath, manwha.Folder);

        if (!Directory.Exists(mangaPath))
            throw new DirectoryNotFoundException($"Manga with title '{manwha.Title}' not found.");

        var fileName = Path.Combine(mangaPath, $"{manwha.Logo}");
        if (File.Exists(fileName))
        {
            var fileBytes = await File.ReadAllBytesAsync(fileName);
            var base64String = Convert.ToBase64String(fileBytes);
            return $"data:image/jpeg;base64,{base64String}";
        }

        throw new FileNotFoundException("Manwha logo not found.");
    }
}

public interface IManwhaService
{
    public Task<ManwhaDto> Get(int key);
    public Task<ListResponse<ManwhaDto>> GetList(FiltersRequest filters);
    public Task<string> GetRandom();
}