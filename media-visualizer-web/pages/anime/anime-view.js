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
    document.getElementById('collection').innerHTML = getListResponse.items.map(item =>
        item.chapters.map(chapter =>
            `<div class="card p-0 hover-effect">
                <img alt="..." class="card-img-top" src="${parseFilePath(item.basePath, [chapter.logo])}" onclick="openInNewTab('${parseFilePath(item.basePath, [chapter.video])}')">
                <div class="card-body">
                    <p class="card-title text-center m-0">${item.title} ${chapter.chapterNumber}</p>
                </div>
            </div>`
        ).join('')
    ).join('');
}