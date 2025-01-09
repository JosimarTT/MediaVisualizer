'use strict'

let getListResponse;

initialize().then(r => {
    console.log('Initialized');
});

async function initialize() {
    await initializePagination(animeApi.getList, updateCollectionContent);
}

function updateCollectionContent(items) {
    document.getElementById('collection').innerHTML = items.map(anime =>
        `<div class="card p-0 hover-effect">
            <img alt="..." class="card-img-top" src="${parseFilePath(anime.basePath, [anime.logo])}" onclick="openInNewTab('${parseFilePath(anime.basePath, [anime.video])}')">
                <div class="card-body">
                    <p class="card-title text-center m-0 text-ellipsis">${anime.title} ${anime.chapterNumber}</p>
                </div>
            </div>`
    ).join('');
}

