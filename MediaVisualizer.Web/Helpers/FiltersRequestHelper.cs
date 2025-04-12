using System.Collections.Specialized;
using System.Web;
using MediaVisualizer.Shared.Requests;

namespace MediaVisualizer.Web.Helpers;

public static class FiltersRequestHelper
{
    public static NameValueCollection BuildFiltersRequest(FiltersRequest filters)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);

        AddQueryParameter(query, "Size", filters.Size?.ToString());
        AddQueryParameter(query, "Page", filters.Page?.ToString());
        AddQueryParameter(query, "SortOrder", filters.SortOrder);
        AddArrayQueryParameters(query, "AuthorIds", filters.AuthorIds);
        AddArrayQueryParameters(query, "TagIds", filters.TagIds);
        AddArrayQueryParameters(query, "BrandIds", filters.BrandIds);
        AddArrayQueryParameters(query, "ArtistIds", filters.ArtistIds);
        AddQueryParameter(query, "Title", filters.Title);

        return query;
    }

    public static NameValueCollection BuildImageRequest(ImageRequest filters)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);

        AddQueryParameter(query, "FilePath", filters.FilePath);
        AddQueryParameter(query, "Width", filters.Width?.ToString());
        AddQueryParameter(query, "Height", filters.Height?.ToString());

        return query;
    }

    private static void AddQueryParameter(NameValueCollection query, string key, string? value)
    {
        if (!string.IsNullOrEmpty(value))
            query[key] = value;
    }

    private static void AddArrayQueryParameters(NameValueCollection query, string key, IEnumerable<int>? values)
    {
        if (values == null)
            return;

        foreach (var value in values)
            query.Add(key, value.ToString());
    }
}