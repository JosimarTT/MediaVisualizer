'use strict'

const brandApi = {
    apiBaseUrl: 'http://localhost:5216/Brand',

    get: async (id) => {
        const response = await fetch(`${brandApi.apiBaseUrl}/${id}`);
        return response.json();
    },

    getList: async () => {
        const response = await fetch(`${brandApi.apiBaseUrl}/GetList`);
        return response.json();
    }
};