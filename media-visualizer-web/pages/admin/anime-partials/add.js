'use strict';

async function searchNew() {
    return await animeApi.searchNew().then(list => {
        for (const anime of list) {
            console.log(anime);
        }
    });
}