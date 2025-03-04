'use strict';

initialize().then(r => {
    console.log('Initialized');
});

async function initialize() {
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
<div class="card hover-effect card-not-last-child">
    <div class="card-body">
        <form>
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
                <label for="anime-brand-input-${i}" class="col-sm-2 col-form-label">Brand</label>
                <div class="col-sm-10" id="brand-dropdown-${i}">
                </div>
            </div>
            <div class="mb-3 row">
                <label for="tags-${i}" class="col-sm-2 col-form-label">Tags</label>
                <div class="col-sm-10">
                    <select multiple class="form-control" id="tags-${i}">
                        <!-- Add options dynamically -->
                    </select>
                </div>
            </div>
            <button type="submit" class="btn btn-primary">Add</button>
        </form>
    </div>
</div>
        `;
        container.insertAdjacentHTML('beforeend', cardHTML);

        // Initialize the dropdown
        const dropdownElements = ['Action', 'Another action', 'Something else here', 'Separated link', 'One more separated link', 'test', 'more tests'];
        initializeDropdown(`brand-dropdown-${i}`, dropdownElements);
    }
}