'use strict'

const manwhaApi = {
    url: `${apiBaseUrl}/Manwha`,

    get: async (id) => {
        const response = await fetch(`${manwhaApi.url}/${id}`);
        return response.json();
    },

    getList: async () => {
        const response = await fetch(`${manwhaApi.url}/GetList`);
        return response.json();
    },

    getRandom: async () => {
        const response = await fetch(`${manwhaApi.url}/GetRandom`);
        return response.json();
    }
};