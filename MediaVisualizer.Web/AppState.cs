namespace MediaVisualizer.Web;

public class AppState
{
    private bool _artistButton;
    private bool _brandButton;
    private bool _tagButton;

    public bool ArtistButton
    {
        get => _artistButton;
        set
        {
            if (_artistButton == value) return;
            _artistButton = value;
            NotifyStateChanged();
        }
    }

    public bool BrandButton
    {
        get => _brandButton;
        set
        {
            if (_brandButton == value) return;
            _brandButton = value;
            NotifyStateChanged();
        }
    }

    public bool TagButton
    {
        get => _tagButton;
        set
        {
            if (_tagButton == value) return;
            _tagButton = value;
            NotifyStateChanged();
        }
    }

    public void EnableButtons(bool artistButton = false, bool brandButton = false, bool tagButton = false)
    {
        ArtistButton = artistButton;
        BrandButton = brandButton;
        TagButton = tagButton;
        NotifyStateChanged();
    }

    public event Action? OnChange;

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}