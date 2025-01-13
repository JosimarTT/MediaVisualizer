'use strict'

const tagApi = {
    apiBaseUrl: 'http://localhost:5216/Tag',

    get: async (id) => {
        const response = await fetch(`${tagApi.apiBaseUrl}/${id}`);
        return response.json();
    },

    getList: async () => {
        const response = await fetch(`${tagApi.apiBaseUrl}/GetList`);
        return response.json();
    }
};