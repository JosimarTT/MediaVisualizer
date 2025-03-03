using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services.Dtos;

public class AnimeDto
{
    public int AnimeId { get; set; }
    public string Folder { get; set; }
    public string Title { get; set; }
    public int ChapterNumber { get; set; }
    public string Logo { get; set; }
    public string Video { get; set; }
    public ICollection<BrandDto> Brands { get; set; }
    public ICollection<TagDto> Tags { get; set; }
    public string BasePath { get; set; }
}