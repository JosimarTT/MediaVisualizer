namespace MediaVisualizer.Services.Dtos;

public class AnimeDto
{
    public int AnimeId { get; set; }
    public string Folder { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int ChapterNumber { get; set; }
    public string Logo { get; set; } = string.Empty;
    public string Video { get; set; } = string.Empty;
    public ICollection<BrandDto> Brands { get; set; } = new List<BrandDto>();
    public ICollection<TagDto> Tags { get; set; } = new List<TagDto>();
    public string BasePath { get; set; } = string.Empty;
}