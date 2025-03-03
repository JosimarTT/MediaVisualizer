'use strict';

const contentIFrame = document.getElementById('content-iframe');
setActiveListGroup();

function createAddNewManhwaIFrame() {
    contentIFrame.innerHTML = `<iframe src="manhwa-partials/add-manhwas.html" style="width: 100%; height: 100%;"></iframe>`;
}

function createAddNewManhwaChapterIFrame() {
    contentIFrame.innerHTML = `<iframe src="manhwa-partials/add-chapters.html" style="width: 100%; height: 100%;"></iframe>`;
}

function createUpdateManhwaIFrame() {
    contentIFrame.innerHTML = `<iframe src="manhwa-partials/update-manhwa.html" style="width: 100%; height: 100%;"></iframe>`;
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