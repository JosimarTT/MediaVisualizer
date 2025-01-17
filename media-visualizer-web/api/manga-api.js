'use strict'

const mangaApi = {
    url: `${apiBaseUrl}/Manga`,

    get: async (id) => {
        const response = await fetch(`${mangaApi.url}/${id}`);
        return response.json();
    },

    getList: async () => {
        const response = await fetch(`${mangaApi.url}/GetList`);
        return response.json();
    },

    getRandom: async () => {
        const response = await fetch(`${mangaApi.url}/GetRandom`);
        return response.json();
    }
};