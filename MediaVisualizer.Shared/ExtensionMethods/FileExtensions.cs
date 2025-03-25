using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace MediaVisualizer.Shared.ExtensionMethods;

public static class FileExtensions
{
    public static async Task<string> ResizeImageToBase64(this string imagePath, double percentage = 100)
    {
        using var image = await Image.LoadAsync(imagePath);
        var newWidth = (int)(image.Width * (percentage / 100));
        var newHeight = (int)(image.Height * (percentage / 100));

        image.Mutate(x => x.Resize(newWidth, newHeight));

        using var ms = new MemoryStream();
        await image.SaveAsync(ms, new JpegEncoder());
        var base64String = Convert.ToBase64String(ms.ToArray());
        return $"data:image/jpeg;base64,{base64String}";
    }
}