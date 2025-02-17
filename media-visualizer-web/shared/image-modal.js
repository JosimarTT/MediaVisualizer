'use strict'

function initializeImageModal(entity) {
    createModal();
    addEventListenerToImageClicks();
    addEventListenerToModalArrowKeys(entity);

    function createModal() {
        const modalHTML = `
        <div class="modal fade" id="images-modal" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-xl modal-dialog-scrollable my-0 h-100 min-vw-100">
                <div class="modal-content border-0 rounded-0">
                    <div class="modal-body text-center p-0">
                          <div class="d-flex flex-wrap justify-content-center"></div>
                    </div>
                    <div class="modal-footer p-0 justify-content-center border-0">
                        <p></p>
                    </div>
                </div>
            </div>
        </div>`;
        document.body.insertAdjacentHTML('beforeend', modalHTML);
    }

    function addEventListenerToImageClicks() {
        document.querySelectorAll('#chapter-collection div').forEach(div => {
            div.addEventListener('click', () => {
                const image = div.querySelector('img');
                const numberPadded = div.getAttribute('data-number-padded');
                const numberFormatted = div.getAttribute('data-number-formatted');
                const modalBody = document.querySelector('#images-modal .modal-body');
                const modalFooter = document.querySelector('#images-modal .modal-footer p');

                modalBody.innerHTML = `<img data-number-formatted="${numberFormatted}" src="${image.src}" alt="Page" class="img-fluid h-100">`;
                modalFooter.textContent = numberPadded;
            });
        });
    }

    function addEventListenerToModalArrowKeys(entity) {
        window.addEventListener('keydown', (e) => {
            if (!['ArrowUp', 'ArrowRight', 'ArrowDown', 'ArrowLeft'].includes(e.key)) return;

            const modal = document.getElementById('images-modal');
            if (!modal.classList.contains('show')) return;

            const currentImage = modal.querySelector('.modal-body img');
            let currentIndex = parseInt(currentImage.getAttribute('data-number-formatted'));
            const fixedPadding = 3;

            if (['ArrowUp', 'ArrowRight'].includes(e.key) && currentIndex < entity.pagesCount) {
                currentIndex++;
            } else if (['ArrowDown', 'ArrowLeft'].includes(e.key) && currentIndex > 1) {
                currentIndex--;
            } else {
                return;
            }

            const numberPadded = String(currentIndex).padStart(fixedPadding, '0');
            const numberFormatted = `${numberPadded}${entity.pageExtension}`;
            const newImage = document.createElement('img');

            newImage.setAttribute('data-number-formatted', numberFormatted);
            newImage.src = currentImage.src.split('/').slice(0, -1).join('/') + '/' + numberFormatted;
            newImage.classList.add('img-fluid', 'h-100');

            modal.querySelector('.modal-body').innerHTML = '';
            modal.querySelector('.modal-body').appendChild(newImage);
            modal.querySelector('.modal-footer p').textContent = numberPadded;
        });
    }
}