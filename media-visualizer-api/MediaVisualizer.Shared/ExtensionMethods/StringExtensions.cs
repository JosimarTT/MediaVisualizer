namespace MediaVisualizer.Shared.ExtensionMethods;

public static class StringExtensions
{
    public static bool IsImage(this string path)
    {
        var extension = Path.GetExtension(path);
        return Constants.imageExtensions.Contains(extension);
    }

    public static bool IsVideo(this string path)
    {
        var extension = Path.GetExtension(path);
        return Constants.videoExtensions.Contains(extension);
    }
}