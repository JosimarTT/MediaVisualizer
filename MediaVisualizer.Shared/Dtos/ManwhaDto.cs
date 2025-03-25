using MediaVisualizer.Services.Dtos;

namespace MediaVisualizer.Shared.Dtos;

public class ManwhaDto
{
    public int ManwhaId { get; set; }
    public string Folder { get; set; }
    public string Title { get; set; }
    public string Logo { get; set; }
    public int ChapterNumber { get; set; }
    public int PagesCount { get; set; }
    public string PageExtension { get; set; }
    public ICollection<TagDto> Tags { get; set; }
    public ICollection<ArtistDto> Artists { get; set; }
    public string BasePath { get; set; }
}