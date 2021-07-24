import { render } from "../node_modules/lit-html/lit-html.js"
export function createNavigation(main, nav){

    const links = {};
    const views = {};
    const forms = {};

    setupNavigation();
    setupForms();

    const navigation = {
        setActiveNav,
        registerView,
        registerForm,
        setUserNav,
        goTo
    }

    return navigation;

    async function goTo(name, ...params) {
        const linkId = Object.entries(links).find(([k,v]) => v == name) || [];
        setActiveNav(linkId[0]);
        const section = await views[name](...params);
        render(section, main);
    }

    function registerView(name, setup, navId) {
        const view = setup(navigation);
        views[name] = view;
        if (navId) {
            links[navId] = name;
        }
    }
    
    function setActiveNav(targetId) {
        [...nav.querySelectorAll(`a`)].forEach(l => {
            if (targetId && l.id == targetId) {
                l.classList.add(`active`);
            }
            else {
                l.classList.remove(`active`);
            }
        })
    }
    
    
    function setupNavigation() {
        setUserNav();
        nav.addEventListener(`click`, (e) => {
            if (e.target.tagName == `A`) {
                const viewName = links[e.target.id];
                if (viewName) {
                    e.preventDefault();
                    goTo(viewName);
                }
            }
        });
    }
    
    function setUserNav() {
        const token = sessionStorage.getItem(`userToken`);
    
        if (token !== null) {
    
            document.getElementById(`user`).style.display = `inline-block`;
            document.getElementById(`guest`).style.display = `none`;
        }
        else {
            document.getElementById(`user`).style.display = `none`;
            document.getElementById(`guest`).style.display = `inline-block`;
        }
    }

    function setupForms() {
        document.body.addEventListener('submit', (e) => {
            const handler = forms[e.target.id];
            if (typeof handler == 'function') {
                e.preventDefault();
                const formData = new FormData(e.target);
                const body = [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {});
                handler(body);
            }
        });
    }

    function registerForm(name, handler) {
        forms[name] = handler;
    }
}