namespace MediaVisualizer.Shared.Dtos;

public class MangaChapterDto
{
    public int MangaChapterId { get; set; }
    public int MangaId { get; set; }
    public int ChapterNumber { get; set; }
    public int PagesCount { get; set; }
    public string Logo { get; set; }
    public string PageExtension { get; set; }
}