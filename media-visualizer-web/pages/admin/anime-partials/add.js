'use strict';

let titles = [];
let tags = [];
let brands = [];
const cardBaseName = 'anime-card-';
const logoInputBaseName = 'logo-input-';
const videoInputBaseName = 'video-input-';
const titleDropdownBaseName = 'title-input-';
const chapterInputBaseName = 'chapter-input-';
const brandDropdownBaseName = 'brand-dropdown-';
const tagDropdownBaseName = 'tag-dropdown-';

initialize().then(r => {
    console.log('add Initialized');
});

async function initialize() {
    [titles, tags, brands] = await Promise.all([animeApi.getTitles(), tagApi.getList(), brandApi.getList()]);
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
                        <label for="${logoInputBaseName}${i}" class="col-sm-2 col-form-label">Logo</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="${logoInputBaseName}${i}" value="${anime.logo}" disabled>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <label for="${videoInputBaseName}${i}" class="col-sm-2 col-form-label">Video</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="${videoInputBaseName}${i}" value="${anime.video}" disabled>
                        </div>
                    </div>
                    <div class="mb-3 row" style="position: relative;">
                        <label class="col-sm-2 col-form-label">Title</label>
                        <div class="col-sm-10" id="${titleDropdownBaseName}${i}">
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <label for="${chapterInputBaseName}${i}" class="col-sm-2 col-form-label">Chapter</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="${chapterInputBaseName}${i}">
                        </div>
                    </div>
                    <div class="mb-3 row" style="position: relative;">
                        <label class="col-sm-2 col-form-label">Brand</label>
                        <div class="col-sm-10" id="${brandDropdownBaseName}${i}">
                        </div>
                    </div>
                    <div class="mb-3 row" style="position: relative;">
                        <label class="col-sm-2 col-form-label">Tags</label>
                        <div class="col-sm-10" id="${tagDropdownBaseName}${i}">
                        </div>
                    </div>
                    <div class="d-flex justify-content-end">
                        <button class="btn btn-primary" onclick="addMAnime(${i})">Add</button>
                    </div>
                </div>
            </div>
        `;
        container.insertAdjacentHTML('beforeend', cardHTML);

        initializeDropdown(`${titleDropdownBaseName}${i}`, titles);
        initializeDropdown(`${brandDropdownBaseName}${i}`, brands.map(x => x.name));
        initializeDropdown(`${tagDropdownBaseName}${i}`, tags.map(x => x.name), true);
    }
}

async function addMAnime(cardId) {
    const cardName = `${cardBaseName}${cardId}`;
    const card = document.getElementById(cardName);
    const logoInput = document.getElementById(`${logoInputBaseName}${cardId}`);
    const videoInput = document.getElementById(`${videoInputBaseName}${cardId}`);
    const titleDropdown = document.getElementById(`${titleDropdownBaseName}${cardId}`);
    const chapterInput = document.getElementById(`${chapterInputBaseName}${cardId}`);
    const brandDropdown = document.getElementById(`${brandDropdownBaseName}${cardId}`);
    const tagDropdown = document.getElementById(`${tagDropdownBaseName}${cardId}`);

    const brandId = brands.find(x => x.name === brandDropdown.querySelector('input').value).brandId;
    const tagIds = Array.from(tagDropdown.querySelectorAll('li div.active')).map(x => tags.find(t => t.name === x.textContent.trim()).tagId);

    const data = {
        animeId: 0,
        logo: logoInput.value,
        video: videoInput.value,
        title: titleDropdown.querySelector('input').value,
        chapterNumber: chapterInput.value,
        brands: [{brandId: brandId}],
        tags: tagIds.map(x => {
            return {tagId: x}
        })
    }

    const response = await animeApi.addOrUpdate(data);
    if (response?.title) {
        card.outerHTML = `
            <div class="alert alert-success" role="alert">
                ${response.title} ${response.chapterNumber} added successfully!
            </div>
    `;
    }
}