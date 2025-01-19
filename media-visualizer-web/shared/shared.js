'use strict'

const apiBaseUrl = 'http://localhost:5216';

const requestFilters = {
    size: 0,
    page: 0,
    sortOrder: '',
    authorIds: [],
    tagIds: [],
    brandIds: [],
    artistIds: [],
    title: ''
}

function getRandomElement(arr) {
    const randomIndex = Math.floor(Math.random() * arr.length);
    return arr[randomIndex];
}

function parseFilePath(basePath, paths) {
    const concatPath = `${basePath}\\${paths.join('\\')}`;
    const normalizedPath = concatPath.replace(/\\/g, '/');
    const encodedPath = normalizedPath.split('/').map(encodeURIComponent).join('/');
    return `file:///${encodedPath}`;
}

function redirectToMangaView() {
    window.location.href = '../manga/manga-view.html';
}

function redirectToManwhaView() {
    window.location.href = '../manwha/manwha-view.html';
}

function redirectToAnimeView() {
    window.location.href = '../anime/anime-view.html';
}

function openInNewTab(url) {
    window.open(url, '_blank');
}

function buildRequestQueryParams(filters) {
    const queryParams = new URLSearchParams();
    if (filters.size) queryParams.append('Size', filters.size);
    if (filters.page) queryParams.append('Page', filters.page);
    if (filters.sortOrder) queryParams.append('SortOrder', filters.sortOrder);
    if (filters.authorIds) filters.authorIds.forEach(id => queryParams.append('AuthorIds', id));
    if (filters.tagIds) filters.tagIds.forEach(id => queryParams.append('TagIds', id));
    if (filters.brandIds) filters.brandIds.forEach(id => queryParams.append('BrandIds', id));
    if (filters.artistIds) filters.artistIds.forEach(id => queryParams.append('ArtistIds', id));
    if (filters.title) queryParams.append('Title', filters.title);
    return queryParams.toString();
}