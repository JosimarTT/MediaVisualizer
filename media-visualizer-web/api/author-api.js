'use strict';

const authorApi = {
    url: `${apiBaseUrl}/Author`,

    get: async (id) => {
        const response = await fetch(`${authorApi.url}/${id}`);
        return response.json();
    },

    getList: async () => {
        const response = await fetch(`${authorApi.url}/GetList`);
        return response.json();
    }
};