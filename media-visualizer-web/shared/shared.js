'use strict'

let isAnime = false;
let isManga = false;
let isManwha = false

const apiBaseUrl = 'http://localhost:5216';

const requestFilters = {
    size: 18,
    page: 1,
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

function updateCollectionContent(items) {
    document.getElementById('collection').innerHTML = items.map(item => {
        let url = './chapter-view.html?id=';
        if (item.animeId) url = `${url}${item.animeId}`;
        if (item.mangaId) url = `${url}${item.mangaId}`;
        if (item.manwhaId) url = `${url}${item.manwhaId}`;
        return `<div class="card p-0 hover-effect" style="height: 356px">
            <a href="${url}" target="_blank" class="h-100">
                <img alt="..." class="card-img object-fit-cover" style="max-height: 300px; border-bottom-left-radius: 0; border-bottom-right-radius: 0" src="${parseFilePath(item.basePath, [item.logo])}">
                <div class="card-body position-absolute bottom-0 w-100 text-white" style="background: #212529; border-radius: var(--bs-card-border-radius); border-top-left-radius: 0;border-top-right-radius: 0">
                    <div class="card-title-container">
                        <p class="card-title text-center m-0 text-ellipsis">${item.title} ${item.chapterNumber}</p>
                    </div>
                </div>
            </a>
        </div>`;
    }).join('');
}

function getIdFromUrl() {
    const url = new URL(window.location.href);
    return parseInt(url.searchParams.get('id'));
}