namespace MediaVisualizer.Shared.Requests;

public class FiltersRequest
{
    public int? Size { get; set; }
    public int? Page { get; set; }
    public string? SortOrder { get; set; }
    public List<int>? AuthorIds { get; set; }
    public List<int>? TagIds { get; set; }
    public List<int>? BrandIds { get; set; }
    public List<int>? ArtistIds { get; set; }
}