'use strict';

let anime;
let manga;
let manwha;

initialize().then(r => console.log('Initialized'));

async function initialize() {
    [anime, manga, manwha] = await Promise.all([animeApi.getRandom(), mangaApi.getRandom(), manwhaApi.getRandom()]);
    document.getElementById('anime-card').querySelector('img').src = parseFilePath(anime.basePath, [anime.logo]);
    document.getElementById('manga-card').querySelector('img').src = parseFilePath(manga.basePath, [manga.logo,`001${manga.pageExtension}`]);
    document.getElementById('manwha-card').querySelector('img').src = parseFilePath(manwha.basePath, [manwha.logo]);
}