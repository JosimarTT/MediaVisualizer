namespace MediaVisualizer.Shared.Dtos;

public class ManwhaChapterDto
{
    public int ManwhaChapterId { get; set; }
    public int ManwhaId { get; set; }
    public int ChapterNumber { get; set; }
    public int PagesCount { get; set; }
    public string Logo { get; set; }
    public string PageExtension { get; set; }
}