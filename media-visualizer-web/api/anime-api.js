'use strict';

const animeApi = {
    url: `${apiBaseUrl}/Anime`,

    get: async (id) => {
        const response = await fetch(`${animeApi.url}/${id}`);
        return response.json();
    },

    getList: async (filters = {}) => {
        const response = await fetch(`${animeApi.url}/GetList?${buildRequestQueryParams(filters)}`);
        return response.json();
    },

    getRandom: async () => {
        const response = await fetch(`${animeApi.url}/GetRandom`);
        return response.json();
    },

    searchNew: async () => {
        const response = await fetch(`${animeApi.url}/SearchNew`);
        return response.json();
    },

    add: async (data) => {
        return {title: "test", aiuda: "aiuda"};
        const response = await fetch(animeApi.url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        return response.json();
    }
};