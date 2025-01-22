'use strict'

let mangaId = getIdFromUrl();
let manga = null;

initialize().then(r => {
    console.log('Initialized');
});

async function initialize() {
    manga = await mangaApi.get(mangaId);
    document.getElementById('chapter-collection').innerHTML = createImageDivs(manga);
    initializeImageModal(manga);
}

function createImageDivs(manga) {
    let imageDivs = '';
    for (let i = 1; i <= manga.pagesCount; i++) {
        const maxLength = String(manga.pagesCount).length;
        const numberPadded = String(i).padStart(maxLength, '0');
        const numberFormatted = numberPadded + manga.pageExtension;
        const imageUrl = `${parseFilePath(manga.basePath, [numberFormatted])}`;
        imageDivs += `<div data-number-padded="${numberPadded}" data-number-formatted="${numberFormatted}" data-bs-toggle="modal" data-bs-target="#images-modal">
            <img src="${imageUrl}" class="manga-page img-fluid hover-effect" style="height: 100%">
        </div>`;
    }
    return imageDivs;
}