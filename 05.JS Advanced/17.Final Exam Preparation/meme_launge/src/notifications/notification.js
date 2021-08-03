import { html, render } from "../../node_modules/lit-html/lit-html.js";

const notificationTemplate = (message) => html`
            <div id="errorBox" class="notification" style="display:block">
                <span>${message}</span>
            </div>
`;

const container = document.getElementById("notifications");

export function notify(message) {
    render(notificationTemplate(message), container);

    setTimeout(() => {
        render("", container);
    }, 3000);
}