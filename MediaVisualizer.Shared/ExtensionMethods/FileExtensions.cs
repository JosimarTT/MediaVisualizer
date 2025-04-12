using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace MediaVisualizer.Shared.ExtensionMethods;

public static class FileExtensions
{
    public static async Task<Stream> ResizeImageToStream(this string filePath, int? width, int? height)
    {
        var image = await Image.LoadAsync(filePath);
        if (width.HasValue || height.HasValue)
        {
            var resizeOptions = new ResizeOptions
            {
                Mode = ResizeMode.Max,
                Size = new Size(width ?? 0, height ?? 0)
            };
            image.Mutate(x => x.Resize(resizeOptions));
        }

        var stream = new MemoryStream();
        await image.SaveAsync(stream, new JpegEncoder());
        stream.Position = 0;
        return stream;
    }
}