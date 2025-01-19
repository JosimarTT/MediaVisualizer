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
        `<div class="card p-0 hover-effect" style="height: 270px">
            <a href="${parseFilePath(item.basePath, [item.video])}" target="_blank" class="h-100">
                <img alt="..." class="card-img h-100 object-fit-cover" src="${parseFilePath(item.basePath, [item.logo])}">
                <div class="card-body position-absolute bottom-0 w-100 text-white" style="background: rgba(0,0,0,0.5)">
                    <div class="card-title-container">
                        <p class="card-title text-center m-0 text-ellipsis">${item.title} ${item.chapterNumber}</p>
                    </div>
                </div>
            </a>
        </div>`
    ).join('');
}