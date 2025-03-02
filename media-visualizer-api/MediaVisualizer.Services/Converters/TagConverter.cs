using MediaVisualizer.DataAccess.Entities;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services.Converters;

public static class TagConverter
{
    public static TagDto ToDto(this Tag tag)
    {
        if (tag == null) return null;
        return new TagDto()
        {
            TagId = tag.TagId,
            Name = tag.Name,
        };
    }

    public static ICollection<TagDto> ToListDto(this ICollection<Tag> tags)
    {
        if (tags == null || tags.Count == 0) return [];
        return tags.Select(x => x.ToDto()).ToList();
    }
}