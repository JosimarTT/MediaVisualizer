using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Manga;

public partial class MangaDetail
{
    private const int pageSize = 5;

    private readonly MangaDto mangaDto = new()
    {
        Folder = @"O\One Piece",
        PagesCount = 43,
        PageExtension = ".jpg"
    };

    private readonly List<string> mangaPages = new();
    private int currentPage = 1;
    [Parameter] public int MangaId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadMore();
    }

    private async Task LoadMore()
    {
        for (var i = 0; i < pageSize && currentPage <= mangaDto.PagesCount; i++, currentPage++)
        {
            var response =
                await Http.GetAsync(
                    $"Manga/GetMangaPage/page?folder={mangaDto.Folder}&page={currentPage}&extension={mangaDto.PageExtension}");
            if (response.IsSuccessStatusCode)
            {
                var mangaPage = await response.Content.ReadAsStringAsync();
                mangaPages.Add(mangaPage);
            }
        }
    }

    public class MangaDto
    {
        public string Folder { get; set; }
        public int PagesCount { get; set; }
        public string PageExtension { get; set; }
    }
}