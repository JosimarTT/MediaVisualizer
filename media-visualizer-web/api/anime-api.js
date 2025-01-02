'use strict'

const apiBaseUrl = 'http://localhost:5216/Anime';

let get = async (id) => {
    const response = await fetch(`${apiBaseUrl}/${id}`);
    return response.json();
}

let getList = async () => {
    const response = await fetch(`${apiBaseUrl}/GetList`);
    return response.json();
}

let getRandom = async () => {
    const response = await fetch(`${apiBaseUrl}/GetRandom`);
    return response.json();
}