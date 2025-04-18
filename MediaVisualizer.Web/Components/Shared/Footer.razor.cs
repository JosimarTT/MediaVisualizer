﻿using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Shared;

public partial class Footer
{
    private const string PREVIOUS = "previous";
    private const string NEXT = "next";
    [Parameter] public int _currentPage { get; set; }
    [Parameter] public int _totalPages { get; set; }
    [Parameter] public EventCallback<int> OnPageChanged { get; set; }

    private bool IsActive(string page)
    {
        return _currentPage.ToString() == page;
    }

    private bool IsPageNavigationDisabled(string navigation)
    {
        return navigation switch
        {
            PREVIOUS => _currentPage == 1,
            NEXT => _currentPage == _totalPages,
            _ => false
        };
    }

    private async Task Previous()
    {
        if (_currentPage > 1)
            await OnPageChanged.InvokeAsync(_currentPage - 1);
    }

    private async Task Next()
    {
        if (_currentPage < _totalPages)
            await OnPageChanged.InvokeAsync(_currentPage + 1);
    }

    private async Task SetActive(string page)
    {
        await OnPageChanged.InvokeAsync(int.Parse(page));
    }
}