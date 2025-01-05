'use strict'

function getRandomElement(arr) {
    const randomIndex = Math.floor(Math.random() * arr.length);
    return arr[randomIndex];
}

function parseFilePath(basePath, paths) {
    return `file:\\${encodeURIComponent(`${basePath}\\${paths.join('\\')}`)}`;
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