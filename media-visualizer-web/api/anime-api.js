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

    getTitles: async () => {
        const response = await fetch(`${animeApi.url}/GetTitles`);
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

    addOrUpdate: async (data) => {
        const response = await fetch(`${animeApi.url}/AddOrUpdate`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        return response.json();
    }
};