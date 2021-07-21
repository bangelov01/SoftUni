import { login } from "../api/data.js";

export function setupLogin(section, navigation) {

    section.querySelector(`form`).addEventListener(`submit`, async (e) => {
        e.preventDefault();

        const formData = new FormData(e.target);
        const data = [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {});

        await login(data.email, data.password)
        document.getElementById(`user`).style.display = `inline-block`;
        document.getElementById(`guest`).style.display = `none`;

        e.target.reset();
        navigation.goTo('catalog');

    });

    return showLogin;

    function showLogin() {
        return section;
    }
}