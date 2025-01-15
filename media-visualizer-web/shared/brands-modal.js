'use strict'

async function initializeBrandsModal() {
    let brands = await brandApi.getList();
    let modal = document.createElement('div');
    modal.innerHTML = `
        <div class="modal fade" id="brandsModal" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-xl modal-dialog-scrollable">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5">Brands</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                          <div id="brand-columns" class="d-flex flex-wrap justify-content-center">
                          </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button id="btn-brand-reset-filters" type="button" class="btn btn-primary">Reset filters</button>
                    </div>
                </div>
            </div>
        </div>`;

    document.body.appendChild(modal);

    let brandColumns = document.getElementById('brand-columns');
    let columnCount = Math.ceil(brands.length / 20);

    for (let i = 0; i < columnCount; i++) {
        let div = document.createElement('div');
        div.className = 'list-group rounded-0';
        for (let j = i * 20; j < (i + 1) * 20 && j < brands.length; j++) {
            let button = document.createElement('button');
            button.type = 'button';
            button.className = 'list-group-item list-group-item-action';
            button.setAttribute('data-brand-id', brands[j].brandId);
            button.setAttribute('data-bs-toggle', 'button');
            button.textContent = brands[j].name;
            button.style.borderColor = 'var(--bs-list-group-border-color)';
            div.appendChild(button);
        }
        brandColumns.appendChild(div);
    }
}