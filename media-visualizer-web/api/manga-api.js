'use strict'

const mangaApi = {
    apiBaseUrl: 'http://localhost:5216/Manga',

    get: async (id) => {
        const response = await fetch(`${mangaApi.apiBaseUrl}/${id}`);
        return response.json();
    },

    getList: async () => {
        const response = await fetch(`${mangaApi.apiBaseUrl}/GetList`);
        return response.json();
    },

    getRandom: async () => {
        const response = await fetch(`${mangaApi.apiBaseUrl}/GetRandom`);
        return response.json();
    }
};