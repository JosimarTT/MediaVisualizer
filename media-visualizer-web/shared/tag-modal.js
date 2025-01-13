'use strict'

async function initializeTagModal() {
    let tags = await tagApi.getList();
    let btnTag = document.getElementById('btn-tags');
    let modal = document.createElement('div');
    modal.innerHTML = `
        <div class="modal fade" id="tagModal" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-xl modal-dialog-scrollable">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5">Tags</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                          <div id="tag-columns" class="d-flex flex-wrap justify-content-center">
                          </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button>
                    </div>
                </div>
            </div>
        </div>`;

    document.body.appendChild(modal);

    let tagColumns = document.getElementById('tag-columns');
    let columnCount = Math.ceil(tags.length / 20);

    for (let i = 0; i < columnCount; i++) {
        let div = document.createElement('div');
        div.className = 'list-group rounded-0';
        for (let j = i * 20; j < (i + 1) * 20 && j < tags.length; j++) {
            let button = document.createElement('button');
            button.type = 'button';
            button.className = 'list-group-item list-group-item-action';
            button.setAttribute('data-tag-id', tags[j].tagId);
            button.setAttribute('data-bs-toggle', 'button');
            button.textContent = tags[j].name;
            button.style.borderColor = 'var(--bs-list-group-border-color)';
            div.appendChild(button);
        }
        tagColumns.appendChild(div);
    }

    tagColumns.addEventListener('click', async (e) => {
        let tagId = e.target.getAttribute('data-tag-id');
        animeApi.options.tagIds.push(tagId);
        console.log(animeApi.options.tagIds);
    });
}