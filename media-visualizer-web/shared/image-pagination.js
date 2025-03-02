'use strict';

let paginationState = {
    page: 1,
    size: 18,
    totalCount: 0,
    totalPages: 0
}

function initializePagination(entity) {
    let paginationDiv = document.getElementById('pagination');
    let chapterCollectionDiv = document.getElementById('chapter-collection');
    let imagesData = getImagesData(entity);

    updatePaginationState();
    updateCollectionContent();
    createPreviousButton();
    createPageButtons();
    createNextButton();
    addEventListenerToArrowKeys();

    function updateCollectionContent() {
        let imageDivs = '';
        const startIndex = (paginationState.page - 1) * paginationState.size;
        const endIndex = Math.min(startIndex + paginationState.size, imagesData.length);

        for (let i = startIndex; i < endIndex; i++) {
            const {imageUrl, numberPadded, numberFormatted} = imagesData[i];
            imageDivs += `<div data-number-padded="${numberPadded}" data-number-formatted="${numberFormatted}" data-bs-toggle="modal" data-bs-target="#images-modal">
            <img src="${imageUrl}" class="img-fluid hover-effect" style="height: 100%">
        </div>`;
        }
        chapterCollectionDiv.innerHTML = imageDivs;
    }

    function getImagesData(entity) {
        let imagesData = [];
        const fixedLength = 3;
        for (let i = 1; i <= entity.pagesCount; i++) {
            const numberPadded = String(i).padStart(fixedLength, '0');
            const numberFormatted = numberPadded + entity.pageExtension;
            const imageUrl = `${parseFilePath(entity.basePath, [numberFormatted])}`;
            imagesData.push({imageUrl: imageUrl, numberPadded: numberPadded, numberFormatted: numberFormatted});
        }
        return imagesData;
    }

    function updatePaginationState() {
        paginationState.totalCount = entity.pagesCount;
        paginationState.totalPages = Math.ceil(entity.pagesCount / requestFilters.size);
        console.log(paginationState)
    }

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

    function addEventListenerToArrowKeys() {
        window.addEventListener('keydown', function (e) {
            if ((['ArrowUp', 'ArrowRight'].includes(e.key) && paginationState.page < paginationState.totalPages) ||
                (['ArrowDown', 'ArrowLeft'].includes(e.key) && paginationState.page > 1)) {
                paginationState.page += ['ArrowUp', 'ArrowRight'].includes(e.key) ? 1 : -1;
                enableDisablePrevButton();
                enableDisableNextButton();
                updateActivePageButton();
                requestFilters.page = paginationState.page;
                updateCollectionContent();
                addEventListenerToImageClicks();
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
                updateCollectionContent();
                addEventListenerToImageClicks();
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
                updateCollectionContent();
                addEventListenerToImageClicks();
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
                updateCollectionContent();
                addEventListenerToImageClicks();
            }
        });
    }

    function addEventListenerToImageClicks() {
        let imageDivs = document.querySelectorAll('#chapter-collection div');
        imageDivs.forEach(div => {
            div.addEventListener('click', () => {
                let image = div.querySelector('img');
                console.log(image);
                let numberPadded = div.getAttribute('data-number-padded');
                let numberFormatted = div.getAttribute('data-number-formatted');
                let modalBody = document.querySelector('#images-modal .modal-body');
                modalBody.innerHTML = `<img data-number-formatted="${numberFormatted}" src="${image.src}" alt="Page" class="img-fluid h-100">`;
                let modalFooter = document.querySelector('#images-modal .modal-footer p');
                modalFooter.innerHTML = `${numberPadded}`;
            });
        });
    }
}