'use strict'

initialize().then(r => {
    console.log('Initialized');
});

async function initialize() {
    await initializeModal(tagModalProperties);
    await initializeModal(brandModalProperties);
    await initializePagination(mangaApi.getList, updateCollectionContent);
}

function updateCollectionContent(items) {
    document.getElementById('collection').innerHTML = items.map(item =>
        `<div class="card p-0 hover-effect">
            <img alt="..." class="card-img-top" src="${parseFilePath(item.basePath, [item.logo])}" onclick="openInNewTab('${parseFilePath(item.basePath, [item.video])}')">
                <div class="card-body">
                    <p class="card-title text-center m-0 text-ellipsis">${item.title} ${item.chapterNumber}</p>
                </div>
            </div>`
    ).join('');
}