import { setupCatalog, showCatalog } from "./catalog.js";
import { setupCreate, showCreate } from "./create.js";
import { setupLogin, showLogin } from "./login.js";
import { setupRegister, showRegister } from "./register.js";
import { setupDetails } from "./details.js";
import { setupEdit } from "./edit.js";


main();

function main() {

    setUserNav();

    const nav = document.querySelector(`nav`);
    const mainElment = document.querySelector(`main`);
    const catalogSection = document.getElementById(`catalogSection`);
    const loginSection = document.getElementById(`loginSection`);
    const registerSection = document.getElementById(`registerSection`);
    const createSection = document.getElementById(`createSection`);
    const detailsSection = document.getElementById(`detailsSection`);
    const editSection = document.getElementById(`editSection`);

    const links = {
        "catalogLink": showCatalog,
        "loginLink": showLogin,
        "registerLink": showRegister,
        "createLink": showCreate
    }

    setupCatalog(mainElment, catalogSection, setActiveNav);
    setupLogin(mainElment, loginSection, setActiveNav);
    setupRegister(mainElment, registerSection, setActiveNav);
    setupCreate(mainElment, createSection, setActiveNav);
    setupDetails(mainElment, detailsSection,setActiveNav);
    setupEdit(mainElment,editSection, setActiveNav)

    setupNavigation();

    //start application in catalog view
    showCatalog();

    function setActiveNav(targetId) {
        [...nav.querySelectorAll(`a`)].forEach(l => {
            if (l.id == targetId) {
                l.classList.add(`active`);
            }
            else {
                l.classList.remove(`active`);
            }
        })
    }


    function setupNavigation() {
        
        document.getElementById(`logoutBtn`).addEventListener(`click`, async (e) => {
            e.preventDefault();
            const token = sessionStorage.getItem('userToken');
            const response = await fetch(`http://localhost:3030/users/logout`, {
                method: `get`,
                headers: { "X-Authorization": token }
            });

            if (!response.ok) {
                const error = await response.json();
                return alert(error.message);
            }

            sessionStorage.removeItem(`userToken`);
            sessionStorage.removeItem(`userId`);
            sessionStorage.removeItem(`email`);

            setUserNav();
            showCatalog();
        });

        nav.addEventListener(`click`, (e) => {
            if (e.target.tagName == `A`) {
                const view = links[e.target.id];
                if (typeof view == "function") {
                    e.preventDefault();
                    view();
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