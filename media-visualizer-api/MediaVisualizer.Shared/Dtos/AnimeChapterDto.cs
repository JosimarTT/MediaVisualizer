namespace MediaVisualizer.Shared.Dtos;

public class AnimeChapterDto
{
    public int AnimeChapterId { get; set; }
    public int AnimeId { get; set; }
    public int ChapterNumber { get; set; }
    public string Logo { get; set; }
    public string Video { get; set; }
}