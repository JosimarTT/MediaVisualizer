namespace MediaVisualizer.Shared.Dtos;

public class ManwhaDto
{
    public int ManwhaKey { get; set; }
    public string Folder { get; set; }
    public string Title { get; set; }
    public ICollection<ManwhaChapterDto> ManwhaChapters { get; set; }
    public ICollection<BrandDto> Brands { get; set; }
    public ICollection<TagDto> Tags { get; set; }
}