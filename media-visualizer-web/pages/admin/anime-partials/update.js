'use strict';

let titles = [];
let animes = [];
let anime;
let brands = [];
let tags = [];

const titleDropdownId = 'title-dropdown';
const chapterDropdownId = 'chapter-dropdown';
const brandDropdownId = 'brand-dropdown';
const tagDropdownId = 'tag-dropdown';

initialize().then(r => {
    console.log('update Initialized');
});

async function initialize() {
    [titles, brands, tags] = await Promise.all([animeApi.getTitles(), brandApi.getList(), tagApi.getList()]);
    initializeDropdown('title-dropdown', titles);
    loadForm();
    document.getElementsByClassName('card')[0].removeAttribute('hidden');
    await filterByTitleEventListener();
}

function loadForm() {
    let form = document.getElementsByClassName('card-body')[0];
    form.insertAdjacentHTML('beforeend', `
                <div class="mb-3 row" style="position: relative;">
                    <label class="col-sm-2 col-form-label" for="chapter-dropdown">Chapter</label>
                    <div class="col-sm-10" id="chapter-dropdown">
                        <input class="form-control" type="text" disabled>
                    </div>
                </div>
                <div class="mb-3 row" style="position: relative;">
                    <label class="col-sm-2 col-form-label" for="brand-dropdown">Brand</label>
                    <div class="col-sm-10" id="brand-dropdown">
                        <input class="form-control" type="text" disabled>
                    </div>
                </div>
                <div class="mb-3 row" style="position: relative;">
                    <label class="col-sm-2 col-form-label" for="tag-dropdown">Tags</label>
                    <div class="col-sm-10" id="tag-dropdown">
                        <input class="form-control" type="text" disabled>
                    </div>
                </div>
            `);
}

async function filterByTitleEventListener() {
    const input = document.getElementById(titleDropdownId).querySelector('input');

    const handleInput = async () => {
        if (input.value === null || input.value.length <= 2) {
            return;
        }

        animes = (await animeApi.getList({title: input.value})).items;
        if (animes.length > 0) showChapterInput();
    };

    input.addEventListener('input', handleInput);
}

function showChapterInput() {
    const chapterDropdown = document.getElementById(chapterDropdownId);
    initializeDropdown(chapterDropdownId, animes.map(x => x.chapterNumber));
    chapterDropdown.parentElement.removeAttribute('hidden');
    filterByChapterEventListener();
}

function filterByChapterEventListener() {
    const input = document.getElementById(chapterDropdownId).querySelector('input');

    const handleInput = () => {
        if (input.value === null || input.value.length <= 0) {
            return;
        }

        console.log('Input changed:', input.value);
        anime = animes.find(x => x.chapterNumber === parseInt(input.value, 10));

        console.log(anime);
        showTagAndBrandInputs();
    };

    input.addEventListener('input', handleInput);
}

function showTagAndBrandInputs() {
    const tagDropdown = document.getElementById(tagDropdownId);
    initializeDropdown(
        tagDropdownId,
        tags.map(x => x.name),
        true,
        undefined,
        anime?.tags?.map(x => x.name) ?? []);

    const brandDropdown = document.getElementById(brandDropdownId);
    initializeDropdown(
        brandDropdownId,
        brands.map(x => x.name),
        false,
        undefined,
        [anime?.brands[0]?.name] ?? []
    )

    tagDropdown.parentElement.removeAttribute('hidden');
    brandDropdown.parentElement.removeAttribute('hidden');
}