'use strict'

function initializeImageModal(entity) {
    createModal();
    addEventListenerToImageClicks();
    addEventListenerToModalArrowKeys(entity);

    function createModal() {
        let modal = document.createElement('div');
        modal.innerHTML = `
        <div class="modal fade" id="images-modal" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-xl modal-dialog-scrollable my-0 h-100 min-vw-100">
                <div class="modal-content border-0 rounded-0">
                    <div class="modal-body text-center p-0">
                          <div class="d-flex flex-wrap justify-content-center">
                          </div>
                    </div>
                    <div class="modal-footer p-0 justify-content-center border-0">
                        <p></p>
                    </div>
                </div>
            </div>
        </div>`;
        document.body.appendChild(modal);
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

    function addEventListenerToModalArrowKeys(entity) {
        window.addEventListener('keydown', function (e) {
            if (!['ArrowUp', 'ArrowRight', 'ArrowDown', 'ArrowLeft'].includes(e.key)) return;

            let modal = document.getElementById('images-modal');
            if (!modal.classList.contains('show')) return;

            let currentImage = modal.querySelector('.modal-body img');
            let numberFormatted = currentImage.getAttribute('data-number-formatted');
            let currentIndex = parseInt(numberFormatted);

            if (['ArrowUp', 'ArrowRight'].includes(e.key) && currentIndex < entity.pagesCount) {
                currentIndex++;
                let numberPadded = String(currentIndex).padStart(String(entity.pagesCount).length, '0');
                let numberFormatted = numberPadded + entity.pageExtension;
                let nextImage = document.createElement('img');
                nextImage.setAttribute('data-number-formatted', numberFormatted);
                nextImage.src = currentImage.src.split('/').slice(0, -1).join('/') + '/' + numberFormatted;
                nextImage.classList.add('img-fluid', 'h-100');
                modal.querySelector('.modal-body').innerHTML = '';
                modal.querySelector('.modal-body').appendChild(nextImage);
                modal.querySelector('.modal-footer p').innerHTML = numberPadded;
            } else if (['ArrowDown', 'ArrowLeft'].includes(e.key) && currentIndex > 1) {
                currentIndex--;
                let numberPadded = String(currentIndex).padStart(String(entity.pagesCount).length, '0');
                let numberFormatted = numberPadded + entity.pageExtension;
                let previousImage = document.createElement('img');
                previousImage.setAttribute('data-number-formatted', numberFormatted);
                previousImage.src = currentImage.src.split('/').slice(0, -1).join('/') + '/' + numberFormatted;
                previousImage.classList.add('img-fluid', 'h-100');
                modal.querySelector('.modal-body').innerHTML = '';
                modal.querySelector('.modal-body').appendChild(previousImage);
                modal.querySelector('.modal-footer p').innerHTML = numberPadded;
            }
        });
    }
}