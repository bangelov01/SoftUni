export function setupUserNav() {

    const token = sessionStorage.getItem('userToken');
    const email = sessionStorage.getItem('email');

    if (token !== null) {
        document.querySelector(".profile span").textContent = `Welcome, ${email}`
        document.querySelector('.user').setAttribute('style', 'display:block');
        document.querySelector('.guest').setAttribute('style', 'display:none');
    } else {
        document.querySelector('.user').setAttribute('style', 'display:none');
        document.querySelector('.guest').setAttribute('style', 'display:block');
    }
}