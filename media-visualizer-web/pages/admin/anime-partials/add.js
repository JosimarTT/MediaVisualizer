'use strict';

let tags = [];
let brands = [];
let cardBaseName = 'new-anime-card-';
let logoInputBaseName = 'anime-logo-input-';
let videoInputBaseName = 'anime-video-input-';
let titleInputBaseName = 'video-title-input-';
let chapterInputBaseName = 'anime-chapter-input-';
let brandDropdownBaseName = 'brand-dropdown-';

initialize().then(r => {
    console.log('add Initialized');
});

async function initialize() {
    [tags, brands] = await Promise.all([tagApi.getList(), brandApi.getList()]);
    let newAnimes = await animeApi.searchNew();
    showMessage(newAnimes.length);
    appendCards(newAnimes);
}

function showMessage(count) {
    if (count > 0)
        return;

    document.getElementById('message-not-found').classList.remove('d-none');
}

function appendCards(newAnimes) {
    if (newAnimes == null || newAnimes.length <= 0)
        return;

    const container = document.getElementById('new-animes');
    for (let i = 0; i < newAnimes.length; i++) {
        const anime = newAnimes[i];
        const cardHTML = `
            <div class="card hover-effect card-not-last-child" id="${cardBaseName}${i}">
                <div class="card-body">
                    <div class="mb-3 row">
                        <label for="anime-logo-input-${i}" class="col-sm-2 col-form-label">Logo</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="anime-logo-input-${i}" value="${anime.logo}" disabled>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <label for="anime-video-input-${i}" class="col-sm-2 col-form-label">Video</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="anime-video-input-${i}" value="${anime.video}" disabled>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <label for="video-title-input-${i}" class="col-sm-2 col-form-label">Title</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="video-title-input-${i}">
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <label for="anime-chapter-input-${i}" class="col-sm-2 col-form-label">Chapter</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="anime-chapter-input-${i}">
                        </div>
                    </div>
                    <div class="mb-3 row" style="position: relative;">
                        <label class="col-sm-2 col-form-label">Brand</label>
                        <div class="col-sm-10" id="brand-dropdown-${i}">
                        </div>
                    </div>
                    <div class="mb-3 row" style="position: relative;">
                        <label class="col-sm-2 col-form-label">Tags</label>
                        <div class="col-sm-10" id="tag-dropdown-${i}">
                        </div>
                    </div>
                    <div class="d-flex justify-content-end">
                        <button class="btn btn-primary" onclick="addMAnime(${i})">Add</button>
                    </div>
                </div>
            </div>
        `;
        container.insertAdjacentHTML('beforeend', cardHTML);

        initializeDropdown(`brand-dropdown-${i}`, brands.map(x => x.name));
        initializeDropdown(`tag-dropdown-${i}`, tags.map(x => x.name), true);
    }
}

async function addMAnime(cardId) {
    const cardName = `${cardBaseName}${cardId}`;
    const card = document.getElementById(cardName);
    const logoInput = document.getElementById(`${logoInputBaseName}${cardId}`);
    const videoInput = document.getElementById(`${videoInputBaseName}${cardId}`);
    const titleInput = document.getElementById(`${titleInputBaseName}${cardId}`);
    const chapterInput = document.getElementById(`${chapterInputBaseName}${cardId}`);
    const brandDropdown = document.getElementById(`${brandDropdownBaseName}${cardId}`);
    const tagDropdown = document.getElementById(`tag-dropdown-${cardId}`);

    const brandId = brands.find(x => x.name === brandDropdown.querySelector('input').value).brandId;
    const tagIds = Array.from(tagDropdown.querySelectorAll('li div.active')).map(x => tags.find(t => t.name === x.textContent.trim()).tagId);

    const data = {
        logo: logoInput.value,
        video: videoInput.value,
        title: titleInput.value,
        chapter: chapterInput.value,
        brand: brandId,
        tags: tagIds
    }

    const response = await animeApi.add(data);
    console.log('response', response);
    if (response?.title) {
        card.outerHTML = `
            <div class="alert alert-success" role="alert">
                ${response.title} added successfully!
            </div>
    `;
    }
}