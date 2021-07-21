export const settings = {
    host: ''
};
export async function get(url) {
    return request(url, createOptions());
}

export async function post(url, data) {
    return request(url, createOptions('post', data));
}

export async function put(url, data) {
    return request(url, createOptions('put', data));
}

export async function del(url) {
    return request(url, createOptions('delete'));
}

export async function login(email, password) {

    const response = await post(settings.host + `/users/login`, { email, password });

    sessionStorage.setItem(`userToken`, response.accessToken);
    sessionStorage.setItem(`userId`, response._id);
    sessionStorage.setItem(`email`, response.email);

    return response;
}

export async function register(email, password) {

    const response = await post(settings.host + `/users/register`, { email, password });

    sessionStorage.setItem(`userToken`, response.accessToken);
    sessionStorage.setItem(`userId`, response._id);
    sessionStorage.setItem(`email`, response.email);

    return response;
}

export async function logout() {
    const response = await get(settings.host + `/users/logout`);

    sessionStorage.removeItem(`userToken`);
    sessionStorage.removeItem(`userId`);
    sessionStorage.removeItem(`email`);

    return response;
}

async function request(url, options) {
    const response = await fetch(url, options);

    if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        throw Error(error.message);
    }

    try {

        return await response.json();

    } catch (error) {

        return response;
    }
}

function createOptions(method = 'get', data) {

    const result = {
        method,
        headers: {}
    }

    if (data) {
        result.headers["Content-Type"] = 'application/json';
        result.body = JSON.stringify(data);
    }

    const token = sessionStorage.getItem('userToken');
    if (token !== null) {
        result.headers["X-Authorization"] = token;
    }

    return result;
}