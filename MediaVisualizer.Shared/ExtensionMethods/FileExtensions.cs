using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace MediaVisualizer.Shared.ExtensionMethods;

public static class FileExtensions
{
    public static async Task<string> ResizeImageToBase64(this string imagePath,
        double? percentage = FilterConstants.DefaultPercentage)
    {
        using var image = await Image.LoadAsync(imagePath);
        var newWidth = (int)(image.Width * (percentage! / 100));
        var newHeight = (int)(image.Height * (percentage! / 100));

        image.Mutate(x => x.Resize(newWidth, newHeight));

        using var ms = new MemoryStream();
        await image.SaveAsync(ms, new JpegEncoder());
        var base64String = Convert.ToBase64String(ms.ToArray());
        return $"data:image/jpeg;base64,{base64String}";
    }

    public static async Task<Stream> ResizeImageToStream(this string filePath, double? percentage)
    {
        // Your logic to resize the image and return a stream
        // Example:
        var image = await Image.LoadAsync(filePath);
        if (percentage.HasValue)
        {
            var width = (int)(image.Width * (percentage.Value / 100));
            var height = (int)(image.Height * (percentage.Value / 100));
            image.Mutate(x => x.Resize(width, height));
        }

        var stream = new MemoryStream();
        await image.SaveAsJpegAsync(stream);
        stream.Position = 0;
        return stream;
    }
}