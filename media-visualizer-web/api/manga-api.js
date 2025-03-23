'use strict';

const mangaApi = {
    url: `${apiBaseUrl}/Manga`,

    get: async (id) => {
        const response = await fetch(`${mangaApi.url}/${id}`);
        return response.json();
    },

    getList: async (filters = {}) => {
        const response = await fetch(`${mangaApi.url}/GetList?${buildRequestQueryParams(filters)}`);
        return response.json();
    },

    getRandom: async () => {
        const response = await fetch(`${mangaApi.url}/GetRandom`);
        return response.json();
    },

    getTitles: async () => {
        try {
            const response = await fetch(`${mangaApi.url}/GetTitles`);
            if (!response.ok) {
                throw new Error(`${response.statusText}`);
            }
            return response.json();
        } catch (error) {
            console.error('Failed to fetch manga titles\n', error);
            showAlert('Failed to fetch manga titles: ' + error.message, 'danger');
            throw error;
        }
    },

    getTitlesToAdd: async () => {
        try {
            const response = await fetch(`${mangaApi.url}/GetTitlesToAdd`);
            if (!response.ok) {
                throw new Error(`${response.statusText}`);
            }
            return response.json();
        } catch (error) {
            console.error('Failed to fetch manga titles to add\n', error);
            showAlert('Failed to fetch manga titles to add: ' + error.message, 'danger');
            throw error;
        }
    }
}