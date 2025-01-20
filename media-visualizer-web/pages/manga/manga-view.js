'use strict'

initialize().then(r => {
    console.log('Initialized');
});

async function initialize() {
    await initializeModal(tagModalProperties);
    await initializeModal(brandModalProperties);
    await initializePagination(mangaApi.getList, updateCollectionContent);
}