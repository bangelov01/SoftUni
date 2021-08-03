import page from "../node_modules/page/page.mjs";
import { render } from "../node_modules/lit-html/lit-html.js";
import { setupUserNav } from "./navigation/navigation.js";
import { logout } from "./api/data.js";

import { homePage } from "./views/home.js";
import { registerPage } from "./views/register.js";
import { loginPage } from "./views/login.js";
import { allMemesPage } from "./views/allMemes.js";
import { createMemePage } from "./views/create.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { myProfilePage } from "./views/myProfile.js";

const main = document.querySelector("main");

page("/", middleWareRender, homePage);
page("/index.html", middleWareRender, homePage);
page("/register", middleWareRender, registerPage);
page("/login", middleWareRender, loginPage);
page("/allMemes", middleWareRender, allMemesPage);
page("/create", middleWareRender, createMemePage);
page("/details/:id", middleWareRender, detailsPage);
page("/edit/:id", middleWareRender, editPage);
page("/myProfile", middleWareRender, myProfilePage);

setupUserNav();
page.start();



function middleWareRender(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setupUserNav = setupUserNav;
    next();
}

document.getElementById('logoutBtn').addEventListener('click', async() => {
    await logout();
    setupUserNav();
    page.redirect("/");
});
