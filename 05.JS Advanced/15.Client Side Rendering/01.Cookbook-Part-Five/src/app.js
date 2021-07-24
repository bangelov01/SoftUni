import { logout as apiLogout } from "./api/data.js"
import { setupCatalog } from "./views/catalog.js";
import { setupCreate } from "./views/create.js";
import { setupLogin } from "./views/login.js";
import { setupRegister } from "./views/register.js";
import { setupDetails } from "./views/details.js";
import { setupEdit, setupDeleted} from "./views/edit.js";

import { createNavigation } from "./navigation.js"

main();

function main() {

    const nav = document.querySelector(`nav`);
    const mainElment = document.querySelector(`main`);

    const navigation = createNavigation(mainElment, nav);

    navigation.registerView('catalog', setupCatalog, "catalogLink");
    navigation.registerView('details', setupDetails);
    navigation.registerView('login', setupLogin, 'loginLink');
    navigation.registerView('register', setupRegister, 'registerLink');
    navigation.registerView('create', setupCreate, 'createLink');
    navigation.registerView('edit', setupEdit);
    navigation.registerView('deleted', setupDeleted);
    document.getElementById('logoutBtn').addEventListener('click', logout);
    document.getElementById('views').remove();
    navigation.goTo('catalog');

    
    async function logout() {

        await apiLogout();
        navigation.setUserNav();
        navigation.goTo('catalog');
    }
}