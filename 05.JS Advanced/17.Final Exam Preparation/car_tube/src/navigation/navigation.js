export function setupUserNav() {

    const token = sessionStorage.getItem('userToken');
    const username = sessionStorage.getItem('username');

    if (token !== null) {
        document.getElementById("guest").style.display = "none";
        document.getElementById("profile").style.display = "block";
        document.getElementById("profile").children[0].textContent = `Welcome ${username}`
    } else {
        document.getElementById("guest").style.display = "block";
        document.getElementById("profile").style.display = "none";
    }
}