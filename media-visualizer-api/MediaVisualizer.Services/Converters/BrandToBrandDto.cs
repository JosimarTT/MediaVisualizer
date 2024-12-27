using MediaVisualizer.DataAccess.Entities.Shared;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services.Converters;

public static class BrandToBrandDto
{
    public static BrandDto ConvertToDto(this Brand brand)
    {
        if (brand == null) return null;
        return new BrandDto
        {
            BrandKey = brand.BrandKey,
            Name = brand.Name,
        };
    }

    public static ICollection<BrandDto> ConvertToListDto(this ICollection<Brand> brands)
    {
        if (brands == null || brands.Count == 0) return [];
        return brands.Select(x => x.ConvertToDto()).ToList();
    }
}