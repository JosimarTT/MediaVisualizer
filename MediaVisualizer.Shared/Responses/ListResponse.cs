﻿namespace MediaVisualizer.Shared.Responses;

public class ListResponse<T>
{
    public ListResponse()
    {
        Items = new List<T>();
    }

    public ListResponse(IEnumerable<T> items, int totalCount, int size, int page)
    {
        Items = items;
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling((double)totalCount / size);
        Size = size;
        Page = page;
    }

    public IEnumerable<T> Items { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public int Size { get; set; }
    public int Page { get; set; }
}