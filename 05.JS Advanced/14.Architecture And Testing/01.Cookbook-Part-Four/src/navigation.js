
export function createNavigation(main, nav){

    const links = {};
    const views = {};

    setupNavigation();

    const navigation = {
        setActiveNav,
        registerView,
        setUserNav,
        goTo
    }

    return navigation;

    async function goTo(name, ...params) {
        const linkId = Object.entries(links).find(([k,v]) => v == name) || [];
        setActiveNav(linkId[0]);
        main.innerHTML = '';
        const section = await views[name](...params);
        main.appendChild(section);
    }

    function registerView(name, section, setup, navId) {
        const view = setup(section, navigation);
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
}