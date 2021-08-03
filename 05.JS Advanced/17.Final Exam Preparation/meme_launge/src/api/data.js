import * as api from "./api.js"

const host = "http://localhost:3030";
api.settings.host = host;

export const register = api.register;
export const login = api.login;
export const logout = api.logout;

async function getMemes() {
    return await api.get(host + "/data/memes?sortBy=_createdOn%20desc");
}

async function getMemesById(id) {
    return await api.get(host + "/data/memes/" + id);
}

async function createMeme(meme) {
    return await api.post(host + "/data/memes", meme);
}

async function updateMeme(id, meme) {
    return await api.put(host + "/data/memes/" + id, meme);
}

async function deleteMeme(id) {
    return await api.del(host + "/data/memes/" + id);
}

async function getUserMemes(userId) {
    return await api.get(host + `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export {
    getMemes,
    getMemesById,
    createMeme,
    updateMeme,
    deleteMeme,
    getUserMemes,
}