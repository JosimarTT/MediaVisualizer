using MediaVisualizer.Shared.Requests;

namespace MediaVisualizer.Web.Services;

public class FiltersStateService : IFiltersStateService
{
    public FiltersRequest Filters { get; private set; } = new();
    public event Action? OnFiltersChanged;

    public void UpdateFilters(FiltersRequest filters)
    {
        Filters = filters;
        OnFiltersChanged?.Invoke();
    }

    public void ClearFilters()
    {
        Filters = new FiltersRequest();
        OnFiltersChanged?.Invoke();
    }
}

public interface IFiltersStateService
{
    FiltersRequest Filters { get; }
    event Action? OnFiltersChanged;
    void UpdateFilters(FiltersRequest filters);
    void ClearFilters();
}