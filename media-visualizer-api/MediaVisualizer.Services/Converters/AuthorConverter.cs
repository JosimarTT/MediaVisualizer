using MediaVisualizer.DataAccess.Entities;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services.Converters;

public static class AuthorConverter
{
    public static AuthorDto ToDto(this Author author)
    {
        if (author == null) return null;

        return new AuthorDto
        {
            AuthorId = author.AuthorId,
            Name = author.Name,
        };
    }

    public static ICollection<AuthorDto> ToListDto(this ICollection<Author> authors)
    {
        if (authors == null || authors.Count == 0) return new List<AuthorDto>();

        return authors.Select(x => x.ToDto()).ToList();
    }
}