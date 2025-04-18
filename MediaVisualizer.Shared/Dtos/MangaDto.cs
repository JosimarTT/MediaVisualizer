﻿namespace MediaVisualizer.Services.Dtos;

public class MangaDto
{
    public int MangaId { get; set; }
    public string Folder { get; set; } = null!;
    public string Title { get; set; } = null!;
    public ICollection<TagDto> Tags { get; set; } = [];
    public ICollection<ArtistDto> Artists { get; set; } = [];
    public string BasePath { get; set; } = null!;
    public double ChapterNumber { get; set; }
    public int PagesCount { get; set; }
    public string Logo { get; set; } = null!;
    public string PageExtension { get; set; } = null!;
}