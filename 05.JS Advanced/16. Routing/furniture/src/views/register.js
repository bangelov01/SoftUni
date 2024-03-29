import { html } from "../../node_modules/lit-html/lit-html.js";
import { register } from "../api/data.js"

const registerTemplate = (onSubmit, isInvalidEmail, isInvalidPass, isInvalidRePass, msg) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Register New User</h1>
        <p>Please fill all fields.</p>
        ${ msg ? html`<p style="color:red">${'*' + msg}</p>` : ""}
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
                <input class=${"form-control" + (isInvalidPass ? " is-invalid" : "" )} id="password" type="password"
                    name="password">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="rePass">Repeat *</label>
                <input class=${"form-control" + (isInvalidRePass ? " is-invalid" : "" )} id="rePass" type="password"
                    name="rePass">
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
        </div>
    </div>
</form>
`;

export async function registerPage(ctx) {

    ctx.setupUserNav();
    ctx.render(registerTemplate(onSubmit));
    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const body = [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v.trim() }), {});

        try {

            if (body.email == '' || body.password == '' || body.rePass == '') {
               return ctx.render(registerTemplate(onSubmit, body.email == '', body.password == '', body.rePass == '', "All fields must be filled!"))
            }
            if (body.password != body.rePass) {
               return ctx.render(registerTemplate(onSubmit, false, true, true, "Passwords dont match!"));
            }

            await register(body.email, body.password);
            ctx.setupUserNav();
            ctx.page.redirect('/');

        } catch (error) {
            alert(error.message);
        }
    }
}