'use strict'

let anime;
let manga;
let manwha;

async function initialize() {
    [anime, manga, manwha] = await Promise.all([animeApi.getRandom(), mangaApi.getRandom(), manwhaApi.getRandom()]);

    var animeChapter = getRandomElement(anime.chapters);
    var mangaChapter = getRandomElement(manga.chapters);
    var manwhaChapter = getRandomElement(manwha.chapters);
    document.getElementById('anime-card').querySelector('img').src = parseFilePath(anime.basePath, [animeChapter.logo]);
    document.getElementById('manga-card').querySelector('img').src = parseFilePath(manga.basePath, [mangaChapter.logo]);
    document.getElementById('manwha-card').querySelector('img').src = parseFilePath(manwha.basePath, [manwhaChapter.logo]);
}

initialize().then(r => console.log('Initialized'));

function getRandomElement(arr) {
    const randomIndex = Math.floor(Math.random() * arr.length);
    return arr[randomIndex];
}

function parseFilePath(basePath, paths) {
    const encodedBasePath = encodeURIComponent(basePath);
    const encodedPaths = paths.map(path => encodeURIComponent(path));
    console.log('encodedBasePath', encodedBasePath)
    console.log('encodedPaths', encodedPaths)
    console.log('result', `file:\\${encodedBasePath}\\${encodedPaths.join('\\')}`)

    return `file:\\${encodedBasePath}\\${encodedPaths.join('\\')}`;
}