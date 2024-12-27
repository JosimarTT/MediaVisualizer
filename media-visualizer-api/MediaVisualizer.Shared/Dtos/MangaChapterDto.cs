namespace MediaVisualizer.Shared.Dtos;

public class MangaChapterDto
{
    public int MangaChapterKey { get; set; }
    public int MangaKey { get; set; }
    public int ChapterNumber { get; set; }
    public int PagesCount { get; set; }
    public string Logo { get; set; }
}