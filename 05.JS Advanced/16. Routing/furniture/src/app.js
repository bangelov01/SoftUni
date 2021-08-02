import page from "../node_modules/page/page.mjs";
import { render } from "../node_modules/lit-html/lit-html.js"
import { setupUserNav, setActiveNav} from "./navigation/navigation.js";
import { logout } from "./api/data.js";
import { clearNotification } from "./notifications/notification.js"

import { homePage } from "./views/home.js";
import { createPage } from "./views/create.js";
import { loginPage } from "./views/login.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { registerPage } from "./views/register.js";
import { myHomePage } from "./views/myHome.js";

const main = document.querySelector('.container');

page('/',middleWareRender, homePage);
page('/create',middleWareRender, createPage);
page('/login',middleWareRender, loginPage);
page('/details/:id',middleWareRender, detailsPage);
page('/edit/:id',middleWareRender, editPage);
page('/register',middleWareRender, registerPage);
page('/myHome',middleWareRender, myHomePage);

setupUserNav();

page.start();

function middleWareRender(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setupUserNav = setupUserNav;
    setActiveNav(ctx.path);
    clearNotification();
    next();
}

document.getElementById('logoutBtn').addEventListener('click', async() => {
    await logout();
    setupUserNav();
    page.redirect("/");
});