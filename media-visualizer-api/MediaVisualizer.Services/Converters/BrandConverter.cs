using MediaVisualizer.DataAccess.Entities;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services.Converters;

public static class BrandConverter
{
    public static BrandDto ToDto(this Brand brand)
    {
        if (brand == null) return null;
        return new BrandDto
        {
            BrandId = brand.BrandId,
            Name = brand.Name,
        };
    }

    public static ICollection<BrandDto> ToListDto(this ICollection<Brand> brands)
    {
        if (brands == null || brands.Count == 0) return [];
        return brands.Select(x => x.ToDto()).ToList();
    }

    public static Brand ToEntity(this BrandDto brandDto)
    {
        if (brandDto == null) return null;
        return new Brand
        {
            BrandId = brandDto.BrandId,
            Name = brandDto.Name,
        };
    }

    public static ICollection<Brand> ToListEntity(this ICollection<BrandDto> brandDtos)
    {
        if (brandDtos == null || brandDtos.Count == 0) return [];
        return brandDtos.Select(x => x.ToEntity()).ToList();
    }
}