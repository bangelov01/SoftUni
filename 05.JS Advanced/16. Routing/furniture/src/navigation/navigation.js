export function setupUserNav(targetId) {

    const token = sessionStorage.getItem('userToken');

    if (token !== null) {
        document.getElementById('user').setAttribute('style', 'display:inline-block');
        document.getElementById('guest').setAttribute('style', 'display:none');
    } else {
        document.getElementById('user').setAttribute('style', 'display:none');
        document.getElementById('guest').setAttribute('style', 'display:inline-block');
    }
}

export function setActiveNav(path) {
    const nav = document.getElementById('navBar');
    const navArray = [...nav.querySelectorAll(`a`)];

    if (path == "/") {
        nav.querySelector('#dashboard').classList.add("active");
    } else {
        nav.querySelector('#dashboard').classList.remove("active");
    }

    for (let i = 1; i < navArray.length; i++) {

        if (path.includes(navArray[i].id)) {
            navArray[i].classList.add(`active`);
        }
        else {
            navArray[i].classList.remove(`active`);
        }
    }
}