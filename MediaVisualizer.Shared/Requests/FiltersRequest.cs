namespace MediaVisualizer.Shared.Requests;

public class FiltersRequest
{
    public int? Size { get; set; } = FilterConstants.DefaultSize;
    public int? Page { get; set; } = FilterConstants.DefaultPage;
    public string? SortOrder { get; set; }
    public List<int>? AuthorIds { get; set; }
    public List<int>? TagIds { get; set; }
    public List<int>? BrandIds { get; set; }
    public List<int>? ArtistIds { get; set; }
    public string? Title { get; set; }
    public double? Percentage { get; set; } = FilterConstants.DefaultPercentage;
}