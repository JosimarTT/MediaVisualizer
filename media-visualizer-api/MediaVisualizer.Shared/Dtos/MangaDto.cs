namespace MediaVisualizer.Shared.Dtos;

public class MangaDto
{
    public int MangaKey { get; set; }
    public string Folder { get; set; }
    public string Title { get; set; }
    public ICollection<MangaChapterDto> Chapters { get; set; }
    public ICollection<TagDto> Tags { get; set; }
    public ICollection<ArtistDto> Artists { get; set; }
    public ICollection<AuthorDto> Authors { get; set; }
    public ICollection<BrandDto> Brands { get; set; }
}