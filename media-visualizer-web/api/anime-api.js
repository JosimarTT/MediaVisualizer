'use strict'

const animeApi = {
    apiBaseUrl: 'http://localhost:5216/Anime',

    options: {
        size: 0,
        page: 0,
        sortOrder: '',
        authorIds: [],
        tagIds: [],
        brandIds: [],
        artistIds: [],
        title: ''
    },

    get: async (id) => {
        const response = await fetch(`${animeApi.apiBaseUrl}/${id}`);
        return response.json();
    },

    getList: async (options = animeApi.options) => {
        const queryParams = new URLSearchParams();

        if (options.size) queryParams.append('Size', options.size);
        if (options.page) queryParams.append('Page', options.page);
        if (options.sortOrder) queryParams.append('SortOrder', options.sortOrder);
        if (options.authorIds) options.authorIds.forEach(id => queryParams.append('AuthorIds', id));
        if (options.tagIds) options.tagIds.forEach(id => queryParams.append('TagIds', id));
        if (options.brandIds) options.brandIds.forEach(id => queryParams.append('BrandIds', id));
        if (options.artistIds) options.artistIds.forEach(id => queryParams.append('ArtistIds', id));
        if (options.title) queryParams.append('Title', options.title);

        const response = await fetch(`${animeApi.apiBaseUrl}/GetList?${queryParams.toString()}`);
        return response.json();
    },

    getRandom: async () => {
        const response = await fetch(`${animeApi.apiBaseUrl}/GetRandom`);
        return response.json();
    }
};