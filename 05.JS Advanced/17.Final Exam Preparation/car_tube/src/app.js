import page from "../node_modules/page/page.mjs";
import { render } from "../node_modules/lit-html/lit-html.js";
import { logout } from "./api/data.js";
import { setupUserNav } from "./navigation/navigation.js";

import { registerPage } from "./views/register.js";
import { homePage } from "./views/home.js";
import { loginPage } from "./views/login.js";
import { allListingsPage } from "./views/allListings.js";
import { createPage } from "./views/create.js";
import { myListingsPage } from "./views/myListings.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { byYearPage } from "./views/byYear.js";





const main = document.getElementById("site-content");

page("/", middleWareRender, homePage);
page("/index.html", middleWareRender, homePage);
page("/register", middleWareRender, registerPage);
page("/login", middleWareRender, loginPage);
page("/allListings", middleWareRender, allListingsPage);
page("/create", middleWareRender, createPage);
page("/myListings", middleWareRender, myListingsPage);
page("/details/:id", middleWareRender, detailsPage);
page("/edit/:id", middleWareRender, editPage);
page("/byYear", middleWareRender, byYearPage);


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