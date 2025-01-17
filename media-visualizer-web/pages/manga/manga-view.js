'use strict'

initialize().then(r => {
    console.log('Initialized');
});

async function initialize() {
    await initializeModal(tagApi.getList, 'tagsModal', 'Tags', 'tag-columns', 'btn-tag-reset-filters');
    await initializeModal(brandApi.getList, 'brandsModal', 'Brands', 'brand-columns', 'btn-brand-reset-filters');
    // await initializePagination(animeApi.getList, updateCollectionContent);
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