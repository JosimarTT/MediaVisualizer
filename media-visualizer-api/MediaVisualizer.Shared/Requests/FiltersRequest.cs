namespace MediaVisualizer.Shared.Requests;

public class FiltersRequest
{
    public int? Size { get; set; }
    public int? Page { get; set; }
    public string? SortOrder { get; set; }
    public List<int>? AuthorKeys { get; set; }
    public List<int>? TagKeys { get; set; }
    public List<int>? BrandKeys { get; set; }
    public List<int>? ArtistKeys { get; set; }
}