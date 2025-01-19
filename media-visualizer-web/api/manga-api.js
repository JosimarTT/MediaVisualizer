'use strict'

const mangaApi = {
    url: `${apiBaseUrl}/Manga`,

    get: async (id) => {
        const response = await fetch(`${mangaApi.url}/${id}`);
        return response.json();
    },

    getList: async (filters = {}) => {
        const response = await fetch(`${mangaApi.url}/GetList?${buildRequestQueryParams(filters)}`);
        return response.json();
    },

    getRandom: async () => {
        const response = await fetch(`${mangaApi.url}/GetRandom`);
        return response.json();
    }
};