'use strict';

const artistApi = {
    url: `${apiBaseUrl}/Artist`,

    get: async (id) => {
        const response = await fetch(`${artistApi.url}/${id}`);
        return response.json();
    },

    getList: async () => {
        const response = await fetch(`${artistApi.url}/GetList`);
        return response.json();
    }
};