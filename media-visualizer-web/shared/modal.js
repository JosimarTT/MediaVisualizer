'use strict'
const tagModalProperties = {
    apiCallBack: tagApi.getList,
    modalId: 'tagsModal',
    modalTitle: 'Tags',
    modalColumns: 'tag-columns',
    modalButtonReset: 'btn-tag-reset-filters',
    dataIdProperty: 'tagId'
};

const brandModalProperties = {
    apiCallBack: brandApi.getList,
    modalId: 'brandsModal',
    modalTitle: 'Brands',
    modalColumns: 'brand-columns',
    modalButtonReset: 'btn-brand-reset-filters',
    dataIdProperty: 'brandId'
}

const artistModalProperties = {
    apiCallBack: artistApi.getList,
    modalId: 'artistsModal',
    modalTitle: 'Artists',
    modalColumns: 'artist-columns',
    modalButtonReset: 'btn-artist-reset-filters',
    dataIdProperty: 'artistId'
}

const authorModalProperties = {
    apiCallBack: authorApi.getList,
    modalId: 'authorsModal',
    modalTitle: 'Authors',
    modalColumns: 'author-columns',
    modalButtonReset: 'btn-author-reset-filters',
    dataIdProperty: 'authorId'
}

async function initializeModal(properties) {
    let items = await properties.apiCallBack();
    let modal = document.createElement('div');
    modal.innerHTML = `
        <div class="modal fade" id="${properties.modalId}" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-xl modal-dialog-scrollable">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5">${properties.modalTitle}</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                          <div id="${properties.modalColumns}" class="d-flex flex-wrap justify-content-center">
                          </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button id="${properties.modalButtonReset}" type="button" class="btn btn-primary">Reset filters</button>
                    </div>
                </div>
            </div>
        </div>`;

    document.body.appendChild(modal);

    let modalColumnsDiv = document.getElementById(properties.modalColumns);
    let columnCount = Math.ceil(items.length / 20);

    for (let i = 0; i < columnCount; i++) {
        let div = document.createElement('div');
        div.className = 'list-group rounded-0';
        for (let j = i * 20; j < (i + 1) * 20 && j < items.length; j++) {
            let button = document.createElement('button');
            button.type = 'button';
            button.className = 'list-group-item list-group-item-action';
            button.setAttribute('data-id', items[j][properties.dataIdProperty]);
            button.setAttribute('data-bs-toggle', 'button');
            button.textContent = items[j].name;
            button.style.borderColor = 'var(--bs-list-group-border-color)';
            div.appendChild(button);
        }
        modalColumnsDiv.appendChild(div);
    }
}