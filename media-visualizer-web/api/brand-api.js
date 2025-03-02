'use strict';

const brandApi = {
    url: `${apiBaseUrl}/Brand`,

    get: async (id) => {
        const response = await fetch(`${brandApi.url}/${id}`);
        return response.json();
    },

    getList: async () => {
        const response = await fetch(`${brandApi.url}/GetList`);
        return response.json();
    }
};