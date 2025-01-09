'use strict'

let anime;
let manga;
let manwha;

initialize().then(r => console.log('Initialized'));

async function initialize() {
    [anime, manga, manwha] = await Promise.all([animeApi.getRandom(), mangaApi.getRandom(), manwhaApi.getRandom()]);
    let manwhaLogo = getRandomElement(manwha.logos);
    let mangaChapter = getRandomElement(manga.chapters);
    document.getElementById('anime-card').querySelector('img').src = parseFilePath(anime.basePath, [anime.logo]);
    document.getElementById('manga-card').querySelector('img').src = parseFilePath(manga.basePath, [mangaChapter.logo]);
    document.getElementById('manwha-card').querySelector('img').src = parseFilePath(manwha.basePath, [manwhaLogo]);
}