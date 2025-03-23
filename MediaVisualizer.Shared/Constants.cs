namespace MediaVisualizer.Shared;

public static class Constants
{
    public const string DbPath =
        @"E:\MediaVisualizer\media-visualizer-api\MediaVisualizer.DataAccess\media-visualizer.db";

    public const string BaseDownloadPath = @"F:\Downloads";
    public const string AnimeDownloadPath = BaseDownloadPath + @"\Animes";
    public const string MangaDownloadPath = BaseDownloadPath + @"\Mangas";
    public const string ManwhaDownloadPath = BaseDownloadPath + @"\Manwhas";

    public const string BaseCollectionPath = @"F:\Documents\Collection";
    public const string AnimeCollectionPath = BaseCollectionPath + @"\Animes";
    public const string MangaCollectionPath = BaseCollectionPath + @"\Mangas";
    public const string ManwhaCollectionPath = BaseCollectionPath + @"\Manwhas";
    public const string AnimeFolderPath = "Animes";
    public const string MangaFolderPath = "Mangas";
    public const string ManwhaFolderPath = "Manwhas";

    public const string DateFormat = "yyyy-MM-dd HH:mm:ss";

    public const int DefaultPage = 1;
    public const int DefaultSize = 18;

    public static readonly List<string> MangaFolders =
    [
        "#", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
    ];

    public static readonly List<string> ImageExtensions = [".jpg", ".jpeg", ".png", ".gif"];
    public static readonly List<string> VideoExtensions = [".mp4", ".mkv", ".avi", ".flv", ".wmv"];
}