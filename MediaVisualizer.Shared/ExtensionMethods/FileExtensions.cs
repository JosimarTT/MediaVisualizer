using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace MediaVisualizer.Shared.ExtensionMethods;

public static class FileExtensions
{
    public static async Task<Stream> ResizeImageToStream(this string filePath, double? percentage)
    {
        var image = await Image.LoadAsync(filePath);
        if (percentage.HasValue)
        {
            var width = (int)(image.Width * (percentage.Value / 100));
            var height = (int)(image.Height * (percentage.Value / 100));
            image.Mutate(x => x.Resize(width, height));
        }

        var stream = new MemoryStream();
        await image.SaveAsync(stream, new JpegEncoder());
        stream.Position = 0;
        return stream;
    }
}