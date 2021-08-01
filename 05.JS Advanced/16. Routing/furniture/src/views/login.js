import { html } from "../../node_modules/lit-html/lit-html.js"
import { login } from "../api/data.js"

const loginTemplate = (onSubmit, isInvalidEmail, isInvalidPassword, msg) => html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Login User</h1>
                <p>Please fill all fields.</p>
                ${msg? html`<p style="color:red">${'*' + msg}</p>` : ""}
            </div>
        </div>
        <form @submit=${onSubmit}>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="email">Email *</label>
                        <input class=${"form-control" + (isInvalidEmail ? " is-invalid" : "" )} id="email" type="text"
                            name="email">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="password">Password *</label>
                        <input class=${"form-control" + (isInvalidPassword ? " is-invalid" : "" )} id="password" type="password"
                            name="password">
                    </div>
                    <input type="submit" class="btn btn-primary" value="Login" />
                </div>
            </div>
        </form>
`;


export async function loginPage(ctx) {

    ctx.setupUserNav();
    ctx.render(loginTemplate(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const body = [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v.trim() }), {});

        try {

            if (body.email == '' || body.password == '') {
                return ctx.render(loginTemplate(onSubmit, body.email == '', body.password == '', "All fields must be filled!"));
            }

            await login(body.email, body.password);

            ctx.setupUserNav();
            ctx.page.redirect('/');

        } catch (error) {
            alert(error.message);
        }
    }
}