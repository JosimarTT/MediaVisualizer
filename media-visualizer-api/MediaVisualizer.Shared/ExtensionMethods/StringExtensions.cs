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

    public static string RemoveExtraSpaces(this string text)
    {
        return RemoveExtraSpacesRegex().Replace(text, " ").Trim();
    }

    public static string RemoveInvalidFolderNameChars(this string text)
    {
        var invalidChars =
            new HashSet<char>(Path.GetInvalidPathChars().Concat(['\\', '/', ':', '*', '?', '"', '<', '>', '|']));
        return new string(text.Where(c => !invalidChars.Contains(c)).ToArray());
    }

    public static string RemoveTextInFirstSquareBrackets(this string text)
    {
        return RemoveTextInFirstSquareBracketsRegex().Replace(text, "", 1);
    }

    public static string FormatTitle(this string title)
    {
        return title
            .RemoveTextInFirstSquareBrackets()
            .RemoveExtraSpaces();
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex RemoveExtraSpacesRegex();

    [GeneratedRegex(@"\[(.*?)\]")]
    private static partial Regex RemoveTextInFirstSquareBracketsRegex();
}