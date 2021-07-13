import { showCatalog } from "./catalog.js";

let main;
let section;
let setActiveNav;

export function setupRegister(mainTarget, sectionTarget, setActiveNavCallback) {
    main = mainTarget;
    section = sectionTarget;
    setActiveNav = setActiveNavCallback;

    section.querySelector(`form`).addEventListener(`submit`, async(e) => {
        e.preventDefault();
    
        const formData = new FormData(e.target);
        const data = [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, {[k]: v}), {});
        
        if (data.email == `` || data.password == ``) {
            return alert(`All fields are required!`)
        }
        else if (data.password != data.rePass) {
            return alert(`Passwords must match!`)
        }
    
        const response = await fetch(`http://localhost:3030/users/register`, {
            method: `post`,
            headers: {"Content-Type": `application/json`},
            body: JSON.stringify({email: data.email, password: data.password})
        });
    
        if (!response.ok) {
            const error = await response.json();
            return alert(error.message);
        }
    
        const responseData = await response.json();
        sessionStorage.setItem(`userToken`, responseData.accessToken);        sessionStorage.setItem(`userToken`, responseData.accessToken);
        sessionStorage.setItem(`userId`, responseData._id);
        sessionStorage.setItem(`email`, responseData.email);

        e.target.reset();

        document.getElementById(`user`).style.display = `inline-block`;
        document.getElementById(`guest`).style.display = `none`;
    
        showCatalog();
    });
}

export function showRegister() {
    setActiveNav('registerLink');
    main.innerHTML = ``;
    main.appendChild(section);
}