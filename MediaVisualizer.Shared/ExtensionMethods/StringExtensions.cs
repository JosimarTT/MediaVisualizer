using System.Text.RegularExpressions;

namespace MediaVisualizer.Shared.ExtensionMethods;

public static partial class StringExtensions
{
    public static bool IsImage(this string path)
    {
        var extension = Path.GetExtension(path);
        return StringConstants.ImageExtensions.Contains(extension);
    }

    public static bool IsVideo(this string path)
    {
        var extension = Path.GetExtension(path);
        return StringConstants.VideoExtensions.Contains(extension);
    }

    public static string RemoveExtraSpaces(this string text)
    {
        return RemoveExtraSpacesRegex().Replace(text, " ");
    }

    public static string RemoveInvalidFolderNameChars(this string text)
    {
        var invalidChars =
            new HashSet<char>(Path.GetInvalidPathChars().Concat(['\\', '/', ':', '*', '?', '"', '<', '>', '|']));
        return new string(text.Where(c => !invalidChars.Contains(c)).ToArray());
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex RemoveExtraSpacesRegex();
}