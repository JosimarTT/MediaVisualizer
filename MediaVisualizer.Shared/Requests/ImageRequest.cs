namespace MediaVisualizer.Shared.Requests;

public class ImageRequest
{
    public string FilePath { get; set; } = string.Empty;
    public int? Height { get; set; }
    public int? Width { get; set; }
}