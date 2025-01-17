'use strict'

const apiBaseUrl = 'http://localhost:5216';

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