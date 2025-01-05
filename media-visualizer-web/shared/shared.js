'use strict'

function getRandomElement(arr) {
    const randomIndex = Math.floor(Math.random() * arr.length);
    return arr[randomIndex];
}

function parseFilePath(basePath, paths) {
    console.log('basePath', basePath);
    console.log('paths', paths);
    const concatPath = `${basePath}\\${paths.join('\\')}`;
    console.log('concatPath', concatPath);
    const encodedPath = concatPath.split('\\').map(encodeURIComponent).join('\\');
    console.log('encodedPath', encodedPath);
    console.log('fileUrl', `file:///${encodedPath}`);
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