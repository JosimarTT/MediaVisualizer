using MediaVisualizer.DataAccess.Entities.Shared;
using MediaVisualizer.Services.Dtos;

namespace MediaVisualizer.Services.Converters;

public static class TagConverter
{
    public static TagDto ToDto(this Tag tag)
    {
        if (tag == null) return null;
        return new TagDto
        {
            TagId = tag.TagId,
            Name = tag.Name
        };
    }

    public static ICollection<TagDto> ToListDto(this ICollection<Tag> tags)
    {
        if (tags == null || tags.Count == 0) return [];
        return tags.Select(x => x.ToDto()).ToList();
    }

    public static Tag ToEntity(this TagDto tagDto)
    {
        if (tagDto == null) return null;
        return new Tag
        {
            TagId = tagDto.TagId,
            Name = tagDto.Name
        };
    }

    public static ICollection<Tag> ToListEntity(this ICollection<TagDto> tagDtos)
    {
        if (tagDtos == null || tagDtos.Count == 0) return [];
        return tagDtos.Select(x => x.ToEntity()).ToList();
    }
}