'use strict'

let mangaId = getIdFromUrl();
let manga = null;

initialize().then(r => {
    console.log('Initialized');
});

async function initialize() {
    manga = await mangaApi.get(mangaId);
    initializePagination(manga);
    initializeImageModal(manga);
}