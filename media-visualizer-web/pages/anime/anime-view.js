'use strict'

let getListResponse;

initialize().then(r => {
    console.log('Initialized');
    updateCollectionContent();
});

async function initialize() {
    getListResponse = await animeApi.getList();
    getListResponse.items = [...getListResponse.items, ...getListResponse.items, ...getListResponse.items, ...getListResponse.items];
    console.log(getListResponse);
}

function updateCollectionContent() {
    document.getElementById('collection').innerHTML = getListResponse.items.map(anime =>
        `<div class="card p-0 hover-effect">
            <img alt="..." class="card-img-top" src="${parseFilePath(anime.basePath, [anime.logo])}" onclick="openInNewTab('${parseFilePath(anime.basePath, [anime.video])}')">
                <div class="card-body">
                    <p class="card-title text-center m-0">${anime.title} ${anime.chapterNumber}</p>
                </div>
            </div>`
    ).join('');
}