import { html } from "../dom.js";
import {register} from "../api/data.js";

const registerTemplate = () => html`
<section id="register">
    <article>
        <h2>Register</h2>
        <form id="registerForm">
            <label>E-mail: <input type="text" name="email"></label>
            <label>Password: <input type="password" name="password"></label>
            <label>Repeat: <input type="password" name="rePass"></label>
            <input type="submit" value="Register">
        </form>
    </article>
</section>
`;

export function setupRegister(navigation) {

    navigation.registerForm('registerForm', async(data) => {
        
        if (data.password != data.rePass) {
            alert(`Passwords must match!`)
        }

        await register(data.email, data.password);
        navigation.setUserNav();
        navigation.goTo('catalog');

    });
    return showRegister;

    function showRegister() {
        return registerTemplate();
    }


    // section.querySelector(`form`).addEventListener(`submit`, async(e) => {
    //     e.preventDefault();
    
    //     const formData = new FormData(e.target);
    //     const data = [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, {[k]: v}), {});
        
    //     if (data.email == `` || data.password == ``) {
    //         return alert(`All fields are required!`)
    //     }
    //     else if (data.password != data.rePass) {
    //         return alert(`Passwords must match!`)
    //     }

    //     await register(data.email, data.password);

    //     document.getElementById(`user`).style.display = `inline-block`;
    //     document.getElementById(`guest`).style.display = `none`;  
        
    //     e.target.reset();
    //     navigation.goTo('catalog');
    // });

    
    // return showRegister;

    // function showRegister() {
    //     return section;
    // }
}
