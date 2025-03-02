'use strict';

let title = document.getElementById('title');
let video = document.getElementById('video');
let animeId = getIdFromUrl();
let anime = null;

initialize().then(r => {
    console.log('Initialized');
});

async function initialize() {
    setInitialVolume();

    anime = await animeApi.get(animeId);
    video.src = parseFilePath(anime.basePath, [anime.video]);

    title.innerText = `${anime.title} ${anime.chapterNumber}`;
}

function setInitialVolume() {
    video.volume = 0.2;
}