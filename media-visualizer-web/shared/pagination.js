'use strict';

let paginationState = {
    page: 0,
    size: 0,
    totalCount: 0,
    totalPages: 0,
    areEventListenersAdded: false
}

async function initializePagination(apiCallback, updateCollectionContentCallback) {
    let paginationDiv = document.getElementById('pagination');

    let apiResponse = await apiCallback(requestFilters);

    updatePaginationState(apiResponse);

    updateCollectionContentCallback(apiResponse.items);

    createPreviousButton();
    createPageButtons();
    createNextButton();
    addEventListenerToArrowKeys();
    addEventListenerToSearchInput();
    addEventListenerToBrandsFilter();
    addEventListenerToTagsFilter();

    function enableDisablePrevButton() {
        const prevButton = document.getElementById('prev-button');
        paginationState.page === 1 ? prevButton.classList.add('disabled') : prevButton.classList.remove('disabled');
    }

    function enableDisableNextButton() {
        const nextButton = document.getElementById('next-button');
        paginationState.totalPages === paginationState.page ? nextButton.classList.add('disabled') : nextButton.classList.remove('disabled');
    }

    function updateActivePageButton() {
        let pageButtons = paginationDiv.querySelectorAll('.page-number');
        pageButtons.forEach(button => button.classList.remove('active'));
        pageButtons[paginationState.page - 1].classList.add('active');
    }

    function updatePaginationState(apiResponse) {
        paginationState.page = apiResponse.page;
        paginationState.size = apiResponse.size;
        paginationState.totalCount = apiResponse.totalCount;
        paginationState.totalPages = apiResponse.totalPages;
    }

    function addEventListenerToTagsFilter() {
        let tagColumns = document.getElementById('tag-columns');
        if (tagColumns == null) return;
        tagColumns.addEventListener('click', async (e) => {
            if (e.target.tagName === 'BUTTON') {
                let tagId = e.target.getAttribute('data-id');
                if (e.target.classList.contains('active')) {
                    requestFilters.tagIds.push(tagId);
                } else {
                    let index = requestFilters.tagIds.indexOf(tagId);
                    if (index > -1) {
                        requestFilters.tagIds.splice(index, 1);
                    }
                }

                apiCallback(requestFilters).then(response => {
                    updatePaginationState(response);
                    createPageButtons();
                    enableDisableNextButton();
                    updateCollectionContent(response.items);
                });
            }
        });

        document.getElementById('btn-tag-reset-filters').addEventListener('click', function () {
            let buttons = tagColumns.querySelectorAll('button');
            buttons.forEach(button => button.classList.remove('active'));
            requestFilters.tagIds = [];
            apiCallback(requestFilters).then(response => {
                updatePaginationState(response);
                createPageButtons();
                enableDisableNextButton();
                updateCollectionContent(response.items);
            });
        });
    }

    function addEventListenerToBrandsFilter() {
        let brandColumns = document.getElementById('brand-columns');
        if (brandColumns == null) return;
        brandColumns.addEventListener('click', async (e) => {
            if (e.target.tagName === 'BUTTON') {
                let brandId = e.target.getAttribute('data-id');
                if (e.target.classList.contains('active')) {
                    requestFilters.brandIds.push(brandId);
                } else {
                    let index = requestFilters.brandIds.indexOf(brandId);
                    if (index > -1) {
                        requestFilters.brandIds.splice(index, 1);
                    }
                }

                apiCallback(requestFilters).then(response => {
                    updatePaginationState(response);
                    createPageButtons();
                    enableDisableNextButton();
                    updateCollectionContent(response.items);
                });
            }
        });

        document.getElementById('btn-brand-reset-filters').addEventListener('click', function () {
            let buttons = brandColumns.querySelectorAll('button');
            buttons.forEach(button => button.classList.remove('active'));
            requestFilters.brandIds = [];
            apiCallback(requestFilters).then(response => {
                updatePaginationState(response);
                createPageButtons();
                enableDisableNextButton();
                updateCollectionContent(response.items);
            });
        });
    }

    function addEventListenerToSearchInput() {
        let searchInput = document.getElementById('search-title');
        if (searchInput == null) return;
        searchInput.addEventListener('input', function (e) {
            const query = e.target.value.trim();
            requestFilters.page = 1;
            requestFilters.title = query;
            apiCallback(requestFilters).then(response => {
                updatePaginationState(response);
                createPageButtons();
                enableDisableNextButton();
                updateCollectionContent(response.items);
            });
        });

    }

    function addEventListenerToArrowKeys() {
        window.addEventListener('keydown', function (e) {
            if ((['ArrowUp', 'ArrowRight'].includes(e.key) && paginationState.page < paginationState.totalPages) ||
                (['ArrowDown', 'ArrowLeft'].includes(e.key) && paginationState.page > 1)) {
                paginationState.page += ['ArrowUp', 'ArrowRight'].includes(e.key) ? 1 : -1;
                enableDisablePrevButton();
                enableDisableNextButton();
                updateActivePageButton();
                requestFilters.page = paginationState.page;
                apiCallback(requestFilters).then(response => {
                    updateCollectionContentCallback(response.items);
                });
            }
        });
    }

    function createPreviousButton() {
        let prevButton = document.createElement('li');
        prevButton.id = 'prev-button';
        prevButton.className = 'page-item';
        prevButton.innerHTML = '<a class="page-link" href="#">Previous</a>';
        paginationDiv.appendChild(prevButton);
        enableDisablePrevButton();
        prevButton.addEventListener('click', function () {
            if (paginationState.page > 1) {
                paginationState.page--;
                enableDisablePrevButton();
                enableDisableNextButton();
                updateActivePageButton();
                requestFilters.page = paginationState.page;
                apiCallback(requestFilters).then(response => {
                    updateCollectionContentCallback(response.items);
                });
            }
        });
    }

    function createPageButtons() {
        let nextButton = document.getElementById('next-button');
        let pageButtons = paginationDiv.querySelectorAll('.page-number');
        pageButtons.forEach(button => button.remove());

        for (let i = 1; i <= paginationState.totalPages; i++) {
            let button = document.createElement('li');
            button.className = 'page-item page-number';
            button.innerHTML = `<a class="page-link" href="#">${i}</a>`;
            if (i === paginationState.page) {
                button.classList.add('active');
            }
            button.addEventListener('click', function () {
                paginationState.page = i;
                enableDisablePrevButton();
                enableDisableNextButton();
                updateActivePageButton();
                requestFilters.page = paginationState.page;
                apiCallback(requestFilters).then(response => {
                    updateCollectionContentCallback(response.items);
                });
            });
            paginationDiv.insertBefore(button, nextButton);
        }
    }

    function createNextButton() {
        let nextButton = document.createElement('li');
        nextButton.id = 'next-button';
        nextButton.className = 'page-item';
        nextButton.innerHTML = '<a class="page-link" href="#">Next</a>';
        paginationDiv.appendChild(nextButton);
        enableDisableNextButton();
        nextButton.addEventListener('click', function () {
            if (paginationState.page < paginationState.totalPages) {
                paginationState.page++;
                enableDisablePrevButton();
                enableDisableNextButton();
                updateActivePageButton();
                requestFilters.page = paginationState.page
                apiCallback(requestFilters).then(response => {
                    updateCollectionContentCallback(response.items);
                });
            }
        });
    }
}