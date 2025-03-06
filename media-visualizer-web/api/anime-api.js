'use strict';

const animeApi = {
    url: `${apiBaseUrl}/Anime`,

    get: async (id) => {
        try {
            const response = await fetch(`${animeApi.url}/${id}`);
            if (!response.ok) {
                throw new Error(`${response.statusText}`);
            }
            return response.json();
        } catch (error) {
            console.error('Failed to fetch anime by id\n', error);
            showAlert('Failed to fetch anime by id: ' + error.message, 'danger');
            throw error;
        }
    },

    getList: async (filters = {}) => {
        try {
            const response = await fetch(`${animeApi.url}/GetList?${buildRequestQueryParams(filters)}`);
            if (!response.ok) {
                throw new Error(`${response.statusText}`);
            }
            return response.json();
        } catch (error) {
            console.error('Failed to fetch anime list\n', error);
            showAlert('Failed to fetch anime list: ' + error.message, 'danger');
            throw error;
        }
    },

    getTitles: async () => {
        try {
            const response = await fetch(`${animeApi.url}/GetTitles`);
            if (!response.ok) {
                throw new Error(`${response.statusText}`);
            }
            return response.json();
        } catch (error) {
            console.error('Failed to fetch anime titles\n', error);
            showAlert('Failed to fetch anime titles: ' + error.message, 'danger');
            throw error;
        }
    },

    getRandom: async () => {
        try {
            const response = await fetch(`${animeApi.url}/GetRandom`);
            if (!response.ok) {
                throw new Error(`${response.statusText}`);
            }
            return response.json();
        } catch (error) {
            console.error('Failed to fetch random anime\n', error);
            showAlert('Failed to fetch random anime: ' + error.message, 'danger');
            throw error;
        }
    },

    searchNew: async () => {
        try {
            const response = await fetch(`${animeApi.url}/SearchNew`);
            if (!response.ok) {
                throw new Error(`${response.statusText}`);
            }
            return response.json();
        } catch (error) {
            console.error('Failed to search new anime\n', error);
            showAlert('Failed to search new anime: ' + error.message, 'danger');
            throw error;
        }
    },

    addOrUpdate: async (data) => {
        try {
            const response = await fetch(`${animeApi.url}/AddOrUpdate`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            });
            if (!response.ok) {
                throw new Error(`${response.statusText}`);
            }
            return response.json();
        } catch (error) {
            console.error('Failed to add or update anime\n', error);
            showAlert('Failed to add or update anime: ' + error.message, 'danger');
            throw error;
        }
    }
};