import { logout as apiLogout } from "./api/data.js"
import { setupCatalog } from "./views/catalog.js";
import { setupCreate } from "./views/create.js";
import { setupLogin } from "./views/login.js";
import { setupRegister } from "./views/register.js";
import { setupDetails } from "./views/details.js";
import { setupEdit } from "./views/edit.js";

import { createNavigation } from "./navigation.js"

main();

function main() {

    const nav = document.querySelector(`nav`);
    const mainElment = document.querySelector(`main`);

    const navigation = createNavigation(mainElment, nav);

    navigation.registerView('catalog', document.getElementById(`catalogSection`), setupCatalog, "catalogLink");
    navigation.registerView('details', document.getElementById(`detailsSection`), setupDetails);
    navigation.registerView('login', document.getElementById(`loginSection`), setupLogin, 'loginLink');
    navigation.registerView('register', document.getElementById(`registerSection`), setupRegister, 'registerLink');
    navigation.registerView('create', document.getElementById(`createSection`), setupCreate, 'createLink');
    navigation.registerView('edit', document.getElementById(`editSection`), setupEdit);
    document.getElementById('logoutBtn').addEventListener('click', logout);
    document.getElementById('views').remove();
    navigation.goTo('catalog');

    
    async function logout() {

        await apiLogout();
        navigation.setUserNav();
        navigation.goTo('catalog');
    }
}