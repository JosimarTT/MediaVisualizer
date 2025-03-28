using System.Collections.Specialized;
using System.Web;
using MediaVisualizer.Shared.Requests;

namespace MediaVisualizer.Web.Helpers;

public static class FiltersRequestHelper
{
    public static NameValueCollection BuildFilterRequest(FiltersRequest filters)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        if (filters.Size.HasValue) query["Size"] = filters.Size.Value.ToString();
        if (filters.Page.HasValue) query["Page"] = filters.Page.Value.ToString();
        if (!string.IsNullOrEmpty(filters.SortOrder)) query["SortOrder"] = filters.SortOrder;
        if (filters.AuthorIds != null) query["AuthorIds"] = string.Join(",", filters.AuthorIds);
        if (filters.TagIds != null) query["TagIds"] = string.Join(",", filters.TagIds);
        if (filters.BrandIds != null) query["BrandIds"] = string.Join(",", filters.BrandIds);
        if (filters.ArtistIds != null) query["ArtistIds"] = string.Join(",", filters.ArtistIds);
        if (!string.IsNullOrEmpty(filters.Title)) query["Title"] = filters.Title;
        if (filters.Percentage.HasValue) query["Percentage"] = filters.Percentage.Value.ToString();

        return query;
    }
}