import * as api from "./api.js"

const host = "http://localhost:3030";
api.settings.host = host;

export const register = api.register;
export const login = api.login;
export const logout = api.logout;

async function getFurnitures(searchParam) {
    
    if (searchParam) {
        return await api.get(host + "/data/catalog?where=" + encodeURIComponent(`make LIKE "${searchParam}"`));
    } else {
        return await api.get(host + "/data/catalog");
    }
}

async function getSearch(searchParam) {
    
}

async function getFurnitureById(id) {
    return await api.get(host + "/data/catalog/" + id);
}

async function createFurniture(furniture) {
    return await api.post(host + "/data/catalog", furniture);
}

async function updateFurniture(id, furniture) {
    return await api.put(host + "/data/catalog/" + id, furniture);
}

async function deleteFurniture(id) {
    return await api.del(host + "/data/catalog/" + id);
}

async function getUserFurniture(userId) {
    return await api.get(host + `/data/catalog?where=_ownerId%3D%22${userId}%22`);
}

export {
    getFurnitures,
    getFurnitureById,
    createFurniture,
    updateFurniture,
    deleteFurniture,
    getUserFurniture,
    getSearch
}