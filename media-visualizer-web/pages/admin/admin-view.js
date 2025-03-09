'use strict';

const contentIFrame = document.getElementById('content-iframe');
setActiveListGroup();

function add(folder) {
    const path = `${folder}/add.html`;
    contentIFrame.innerHTML = `<iframe src=${path} style="width: 100%; height: 100%;"></iframe>`;
}

function update(folder) {
    const path = `${folder}/update.html`;
    contentIFrame.innerHTML = `<iframe src=${path} style="width: 100%; height: 100%;"></iframe>`;
}

function setActiveListGroup() {
    document.querySelectorAll('.list-group-item').forEach(item => {
        item.addEventListener('click', () => {
            document.querySelectorAll('.list-group-item').forEach(item => item.classList.remove('active'));
            item.classList.add('active');
        });
    });
    console.log('click');
}