'use strict'

function getRandomElement(arr) {
    const randomIndex = Math.floor(Math.random() * arr.length);
    return arr[randomIndex];
}

function parseFilePath(basePath, paths) {
    return `file:\\${encodeURIComponent(`${basePath}\\${paths.join('\\')}`)}`;
}