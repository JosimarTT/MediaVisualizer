'use strict';

function initializeDropdown(dropdownId, items) {
    const dropdown = document.getElementById(dropdownId);

    const dropdownHTML = `
        <div class="dropdown-menu d-block position-static pt-0 mx-0 overflow-hidden w-280px border-0" data-bs-theme="dark">
            <form class="p-2 mb-2 bg-dark border-bottom border-dark">
                <input type="search" class="form-control bg-dark" autocomplete="false" placeholder="Type to filter..." id="anime-brand-input">
            </form>
            <ul class="list-unstyled mb-0 border rounded-2" style="z-index: 9999; position: absolute; width: 756.8333px; background: var(--bs-dark); max-height: 160px; overflow-y: auto;" hidden>
                ${items.map(item => `
                    <li><a class="dropdown-item d-flex align-items-center gap-2 py-2" href="#">
                        <span class="d-inline-block bg-success rounded-circle p-1"></span>
                        ${item}
                    </a></li>
                `).join('')}
            </ul>
        </div>
    `;

    dropdown.innerHTML = dropdownHTML;

    const input = dropdown.querySelector('input');
    const ul = dropdown.querySelector('ul');

    input.addEventListener('click', function () {
        ul.hidden = !ul.hidden;
    });

    input.addEventListener('input', function () {
        const filter = input.value.toLowerCase();
        ul.querySelectorAll('li').forEach(li => {
            const text = li.textContent.toLowerCase();
            li.style.display = text.includes(filter) ? '' : 'none';
        });
    });

    ul.querySelectorAll('li').forEach(li => {
        li.addEventListener('click', function () {
            input.value = li.textContent.trim();
            ul.hidden = true;
        });
    });
}