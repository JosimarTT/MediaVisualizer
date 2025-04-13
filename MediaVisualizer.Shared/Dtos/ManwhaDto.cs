using MediaVisualizer.Services.Dtos;

namespace MediaVisualizer.Shared.Dtos;

public class ManwhaDto
{
    public int ManwhaId { get; set; }
    public string Folder { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string[] Logos { get; set; } = [];
    public ICollection<ManwhaChapterDto> Chapters { get; set; } = [];
    public ICollection<TagDto> Tags { get; set; } = [];
    public ICollection<ArtistDto> Artists { get; set; } = [];
    public string BasePath { get; set; } = string.Empty;
}

public class ManwhaChapterDto
{
    public string? Logo { get; set; }
    public int ChapterNumber { get; set; }
    public int PagesCount { get; set; }
    public string PageExtension { get; set; }
}