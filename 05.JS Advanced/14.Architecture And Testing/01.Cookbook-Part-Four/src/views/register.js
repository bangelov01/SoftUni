import {register} from "../api/data.js"

export function setupRegister(section, navigation) {

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

        await register(data.email, data.password);

        document.getElementById(`user`).style.display = `inline-block`;
        document.getElementById(`guest`).style.display = `none`;  
        
        e.target.reset();
        navigation.goTo('catalog');
    });

    
    return showRegister;

    function showRegister() {
        return section;
    }
}
