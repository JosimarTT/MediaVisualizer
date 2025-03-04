'use strict';

function initializeDropdown(dropdownId, items, isMultipleSelection = false) {
    const dropdown = document.getElementById(dropdownId);

    createDropdown();

    const input = dropdown.querySelector('input');
    const ul = dropdown.querySelector('ul');
    const selectedItemsContainer = dropdown.querySelector('.selected-items');

    toggleItemsEventListener();
    filterItemsEventListener();

    if (isMultipleSelection) {
        addActiveClassOnInputCLickEventListener();
    } else {
        assignSelectedItemEventListener();
    }


    function createDropdown() {
        const dropdownHTML = `
        <div class="dropdown-menu d-block position-static pt-0 mx-0 overflow-hidden w-280px border-0" data-bs-theme="dark">
            <form class="p-2 mb-2 bg-dark border-bottom border-dark">
                <div class="selected-items d-flex flex-wrap gap-1 mb-2"></div>
                <input type="search" class="form-control bg-dark" autocomplete="false" placeholder="Type to filter..." id="anime-brand-input">
            </form>
            <ul class="list-unstyled mb-0 border rounded-2" style="z-index: 9999; position: absolute; width: 756.8333px; background: var(--bs-dark); max-height: 160px; overflow-y: auto;" hidden>
                ${items.map(item => `
                    <li><div class="dropdown-item d-flex align-items-center gap-2 py-2">
                        <label class="form-check-label">${item}</label>
                    </div></li>
                `).join('')}
            </ul>
        </div>
    `;
        dropdown.innerHTML = dropdownHTML;
    }

    function toggleItemsEventListener() {
        input.addEventListener('click', function () {
            ul.hidden = !ul.hidden;
        });
    }

    function filterItemsEventListener() {
        input.addEventListener('input', function () {
            const filter = input.value.toLowerCase();
            ul.querySelectorAll('li').forEach(li => {
                const text = li.textContent.toLowerCase();
                li.style.display = text.includes(filter) ? '' : 'none';
            });
        });
    }

    function assignSelectedItemEventListener() {
        ul.querySelectorAll('li').forEach(li => {
            li.addEventListener('click', function () {
                input.value = li.textContent.trim();
                ul.hidden = true;
            });
        });
    }

    function addActiveClassOnInputCLickEventListener() {
        ul.querySelectorAll('li').forEach(li => {
            li.addEventListener('click', function () {
                const div = li.querySelector('div');
                if (div.classList.contains('active')) {
                    div.classList.remove('active');
                    removeSelectedItem(div.textContent.trim());
                } else {
                    div.classList.add('active');
                    addSelectedItem(div.textContent.trim());
                }
            });
        });
    }

    function addSelectedItem(value) {
        const buttonHTML = `
        <button type="button" class="btn btn-secondary btn-sm">
            ${value} <span class="btn-close" aria-hidden="true" style="padding-left: 1rem;padding-right: 0.25rem;margin-left: 0.25rem;font-size: 10px"></span>
        </button>
    `;
        selectedItemsContainer.insertAdjacentHTML('beforeend', buttonHTML);

        const button = selectedItemsContainer.lastElementChild;
        const closeButton = button.querySelector('.btn-close');
        closeButton.addEventListener('click', function (event) {
            event.stopPropagation();
            removeSelectedItem(value);
            const li = Array.from(ul.querySelectorAll('li')).find(li => li.textContent.includes(value));
            if (li) {
                const div = li.querySelector('div');
                if (div) {
                    div.classList.remove('active');
                }
            }
        });
    }

    function removeSelectedItem(value) {
        const buttons = Array.from(selectedItemsContainer.querySelectorAll('button'));
        const button = buttons.find(btn => btn.textContent.includes(value));
        if (button) {
            button.remove();
        }
    }
}
