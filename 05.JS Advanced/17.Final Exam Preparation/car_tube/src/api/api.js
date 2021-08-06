const settings = {
    host: ""
}

async function get(url) {
    return request(url, options());
}

async function post(url, data) {
    return request(url, options("POST", data));
}

async function put(url, data) {
    return request(url, options("PUT", data));
}

async function del(url) {
    return request(url, options("DELETE"));
}

async function register(username, password) {

    const response = await post(settings.host + "/users/register", {username, password});

    sessionStorage.setItem("userToken", response.accessToken);
    sessionStorage.setItem("userId", response._id);
    sessionStorage.setItem("username", response.username);

    return response;
}

async function login(username, password) {

    const response = await post(settings.host + "/users/login", {username, password});

    sessionStorage.setItem("userToken", response.accessToken);
    sessionStorage.setItem("userId", response._id);
    sessionStorage.setItem("username", response.username);

    return response;
}

async function logout() {

    const response = await get(settings.host + "/users/logout");

    sessionStorage.removeItem("userToken");
    sessionStorage.removeItem("userId");
    sessionStorage.removeItem("username");

    return response;
}

async function request(url, options) {

    try {
        const response = await fetch(url, options);

        if (!response.ok) {
            const error = await response.json();
            throw new Error(error.message);
        }

        try {
            
            return await response.json();

        } catch (error) {
            
            return response;
        }
        
    } catch (error) {
        throw error;
    }
}

function options(method = "GET", data) {

    const result = {
        method,
        headers: {}
    }

    if (data) {
        result.headers["Content-Type"] = "application/json";
        result.body = JSON.stringify(data);
    }

    const token = sessionStorage.getItem("userToken");
    if (token !== null) {
        result.headers["X-Authorization"] = token;
    }

    return result;
}

export {
    get,
    post,
    put,
    del,
    register,
    login,
    logout,
    settings
}