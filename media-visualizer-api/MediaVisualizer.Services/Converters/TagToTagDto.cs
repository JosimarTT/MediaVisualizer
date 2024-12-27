using MediaVisualizer.DataAccess.Entities.Shared;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services.Converters;

public static class TagToTagDto
{
    public static TagDto ConvertToDto(this Tag tag)
    {
        if (tag == null) return null;
        return new TagDto()
        {
            TagKey = tag.TagKey,
            Name = tag.Name,
        };
    }

    public static ICollection<TagDto> ConvertToListDto(this ICollection<Tag> tags)
    {
        if (tags == null || tags.Count == 0) return [];
        return tags.Select(x => x.ConvertToDto()).ToList();
    }
}