using MediaVisualizer.Services.Dtos;

namespace MediaVisualizer.Web.Helpers;

public class PersistentDataHelper
{
    public List<BrandDto> Brands { get; set; } = [];

    public List<ArtistDto> Artists { get; set; } = [];

    public List<TagDto> Tags { get; set; } = [];
}