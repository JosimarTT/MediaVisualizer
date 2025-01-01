namespace MediaVisualizer.Shared.Dtos;

public class AnimeDto
{
    public int AnimeId { get; set; }
    public string Folder { get; set; }
    public string Title { get; set; }
    public ICollection<AnimeChapterDto> Chapters { get; set; }
    public ICollection<BrandDto> Brands { get; set; }
    public ICollection<TagDto> Tags { get; set; }
}