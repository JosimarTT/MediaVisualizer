'use strict'

const tagApi = {
    url: `${apiBaseUrl}/Tag`,

    get: async (id) => {
        const response = await fetch(`${tagApi.url}/${id}`);
        return response.json();
    },

    getList: async () => {
        const response = await fetch(`${tagApi.url}/GetList`);
        return response.json();
    }
};