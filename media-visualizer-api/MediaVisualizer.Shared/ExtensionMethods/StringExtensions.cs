using System.Text.RegularExpressions;

namespace MediaVisualizer.Shared.ExtensionMethods;

public static partial class StringExtensions
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

    public static string RemoveDoubleSpaces(this string text)
    {
        return RemoveDoubleSpaces().Replace(text, " ");
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex RemoveDoubleSpaces();
}