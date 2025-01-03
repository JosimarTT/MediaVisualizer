'use strict'

const animeApi = {
    apiBaseUrl:'http://localhost:5216/Manwha',

    get: async (id) => {
        const response = await fetch(`${animeApi.apiBaseUrl}/${id}`);
        return response.json();
    },

    getList: async () => {
        const response = await fetch(`${animeApi.apiBaseUrl}/GetList`);
        return response.json();
    },

    getRandom: async () => {
        const response = await fetch(`${animeApi.apiBaseUrl}/GetRandom`);
        return response.json();
    }
};