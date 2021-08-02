import { html, render } from "../../node_modules/lit-html/lit-html.js";

const notificationTemplate = (message) => html`
<section @click=${clearNotification} id="notification">
    ${message}
    <span style="margin-left: 25px">\u2716</span>
</section>
`;

const container = document.createElement("div");
document.body.appendChild(container);

export function notify(message) {
    render(notificationTemplate(message), container)
}

export function clearNotification() {
    render("", container);
}