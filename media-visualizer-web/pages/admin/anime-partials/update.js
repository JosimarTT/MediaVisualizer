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
    document.getElementsByClassName('card')[0].removeAttribute('hidden');
    await filterByTitleEventListener();
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

async function update() {
    const titleDropdown = document.getElementById(titleDropdownId);
    const chapterDropdown = document.getElementById(chapterDropdownId);
    const brandDropdown = document.getElementById(brandDropdownId);
    const tagDropdown = document.getElementById(tagDropdownId);

    const selectedBrand = brands.find(x => x.name === brandDropdown.querySelector('input').value);
    const selectedTags = Array.from(tagDropdown.querySelectorAll('li div.active')).map(x => tags.find(t => t.name === x.textContent.trim()));

    const data = {
        animeId: anime.animeId,
        logo: anime.logo,
        video: anime.video,
        title: titleDropdown.querySelector('input').value,
        chapterNumber: chapterDropdown.querySelector('input').value,
        brands: [selectedBrand],
        tags: selectedTags
    }

    const response = await animeApi.update(data.animeId, data);
    if (response?.title) {
        animes = [];
        anime = undefined;
        document.getElementsByClassName('card')[0].outerHTML = `
            <div class="alert alert-success" role="alert">
                ${response.title} ${response.chapterNumber} updated successfully!
            </div>
        `;
    }
}