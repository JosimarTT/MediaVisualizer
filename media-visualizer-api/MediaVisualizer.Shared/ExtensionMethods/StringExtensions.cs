namespace MediaVisualizer.Shared.ExtensionMethods;

public static class StringExtensions
{
    public static bool IsImage(this string path)
    {
        var extension = Path.GetExtension(path);
        return Constants.ImageExtensions.Contains(extension);
    }

    public static bool IsVideo(this string path)
    {
        var extension = Path.GetExtension(path);
        return Constants.VideoExtensions.Contains(extension);
    }
}