'use strict'

let paginationState = {
    page: 0,
    size: 0,
    totalCount: 0,
    totalPages: 0,
    areEventListenersAdded: false,
    searchQuery: animeApi.options
}

async function initializePagination(apiCallback, updateCollectionContentCallback) {
    let paginationDiv = document.getElementById('pagination');
    paginationDiv.innerHTML = '';

    let apiResponse = await apiCallback();

    updatePaginationState(apiResponse);

    updateCollectionContentCallback(apiResponse.items);

    // Create Previous button
    let prevButton = document.createElement('li');
    prevButton.className = 'page-item';
    prevButton.innerHTML = '<a class="page-link" href="#">Previous</a>';
    enableDisablePrevButton();
    prevButton.addEventListener('click', function () {
        if (paginationState.page > 1) {
            paginationState.page--;
            enableDisablePrevButton();
            enableDisableNextButton();
            updateActivePageButton();
            apiCallback({page: paginationState.page}).then(response => {
                updateCollectionContentCallback(response.items);
            });
        }
    });
    paginationDiv.appendChild(prevButton);

    // Create page buttons
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
            apiCallback({page: paginationState.page}).then(response => {
                updateCollectionContentCallback(response.items);
            });
        });
        paginationDiv.appendChild(button);
    }

    // Create Next button
    let nextButton = document.createElement('li');
    nextButton.className = 'page-item';
    nextButton.innerHTML = '<a class="page-link" href="#">Next</a>';
    enableDisableNextButton();
    nextButton.addEventListener('click', function () {
        if (paginationState.page < paginationState.totalPages) {
            paginationState.page++;
            enableDisablePrevButton();
            enableDisableNextButton();
            updateActivePageButton();
            apiCallback({page: paginationState.page}).then(response => {
                updateCollectionContentCallback(response.items);
            });
        }
    });
    paginationDiv.appendChild(nextButton);

    window.addEventListener('keydown', function (e) {
        if ((['ArrowUp', 'ArrowRight'].includes(e.key) && paginationState.page < paginationState.totalPages) ||
            (['ArrowDown', 'ArrowLeft'].includes(e.key) && paginationState.page > 1)) {
            paginationState.page += ['ArrowUp', 'ArrowRight'].includes(e.key) ? 1 : -1;
            enableDisablePrevButton();
            enableDisableNextButton();
            updateActivePageButton();
            apiCallback({page: paginationState.page}).then(response => {
                updateCollectionContentCallback(response.items);
            });
        }
    });

    document.getElementById('search-title').addEventListener('input', function (e) {
        const query = e.target.value;
        if (query.length >= 3) {
            apiCallback({title: query}).then(response => {
                updatePaginationState(response);
                createPageButtons();
                enableDisableNextButton();
                updateCollectionContent(response.items);
            });
        } else if (query.length === 0) {
            apiCallback().then(response => {
                updatePaginationState(response);
                createPageButtons();
                enableDisableNextButton();
                updateCollectionContent(response.items);
            });
        }
    });

    function enableDisablePrevButton() {
        paginationState.page === 1 ? prevButton.classList.add('disabled') : prevButton.classList.remove('disabled');
    }

    function enableDisableNextButton() {
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

    function createPageButtons() {
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
                apiCallback({page: paginationState.page}).then(response => {
                    updateCollectionContentCallback(response.items);
                });
            });
            paginationDiv.insertBefore(button, nextButton);
        }
    }

    function addEventListenerToTagFilter() {
        let tagFilter = document.getElementById('tag-filter');
        if (tagFilter != null) {
            tagFilter.addEventListener('change', function (e) {
                let tagId = e.target.value;
                if (tagId === '0') {
                    apiCallback().then(response => {
                        updatePaginationState(response);
                        createPageButtons();
                        enableDisableNextButton();
                        updateCollectionContent(response.items);
                    });
                } else {
                    apiCallback({tagIds: [tagId]}).then(response => {
                        updatePaginationState(response);
                        createPageButtons();
                        enableDisableNextButton();
                        updateCollectionContent(response.items);
                    });
                }
            });
        }
    }
}