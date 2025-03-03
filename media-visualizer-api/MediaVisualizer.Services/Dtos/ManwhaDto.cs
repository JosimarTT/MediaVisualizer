using MediaVisualizer.Services.Dtos;

namespace MediaVisualizer.Shared.Dtos;

public class ManwhaDto
{
    public int ManwhaId { get; set; }
    public string Folder { get; set; }
    public string Title { get; set; }
    public ICollection<ManwhaChapterDto> Chapters { get; set; }
    public ICollection<string> Logos { get; set; }
    public ICollection<BrandDto> Brands { get; set; }
    public ICollection<TagDto> Tags { get; set; }
    public ICollection<ArtistDto> Artists { get; set; }
    public ICollection<AuthorDto> Authors { get; set; }
    public string BasePath { get; set; }
}