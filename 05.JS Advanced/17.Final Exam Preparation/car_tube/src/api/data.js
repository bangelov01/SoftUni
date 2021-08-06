import * as api from "./api.js"

const host = "http://localhost:3030";
api.settings.host = host;

export const register = api.register;
export const login = api.login;
export const logout = api.logout;

async function getCars() {
    return await api.get(host + "/data/cars?sortBy=_createdOn%20desc");
}

async function search(query) {
    return await api.get(host + `/data/cars?where=year%3D${query}`);
}

async function getCarById(id) {
    return await api.get(host + "/data/cars/" + id);
}

async function createCar(car) {
    return await api.post(host + "/data/cars", car);
}

async function updateCar(id, car) {
    return await api.put(host + "/data/cars/" + id, car);
}

async function deleteCar(id) {
    return await api.del(host + "/data/cars/" + id);
}

async function getUserCars(userId) {
    return await api.get(host + `/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export {
    getCars,
    search,
    getCarById,
    createCar,
    updateCar,
    deleteCar,
    getUserCars,
}