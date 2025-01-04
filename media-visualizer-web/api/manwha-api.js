'use strict'

const manwhaApi = {
    apiBaseUrl: 'http://localhost:5216/Manwha',

    get: async (id) => {
        const response = await fetch(`${manwhaApi.apiBaseUrl}/${id}`);
        return response.json();
    },

    getList: async () => {
        const response = await fetch(`${manwhaApi.apiBaseUrl}/GetList`);
        return response.json();
    },

    getRandom: async () => {
        const response = await fetch(`${manwhaApi.apiBaseUrl}/GetRandom`);
        return response.json();
    }
};