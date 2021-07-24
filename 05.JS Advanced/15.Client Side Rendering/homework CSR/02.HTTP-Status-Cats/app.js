import { cats } from "./catSeeder.js";
import { html, render } from "../node_modules/lit-html/lit-html.js";

function solve() {

    const ulTemplate = (cats) => html`
    <ul @click=${onClick}>
        ${cats.map(catCardTemplate)}
    </ul>
`;

    const catCardTemplate = (cat) => html`
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn">Show status code</button>
        <div class="status" style="display: none" id="100">
            <h4>${cat.statusCode}</h4>
            <p>${cat.statusMessage}</p>
        </div>
    </div>
</li>
`;

    render(ulTemplate(cats), document.getElementById('allCats'));

    function onClick(e) {
        let statusBox = e.target.nextElementSibling;
        if (statusBox.style.display == 'none') {
            statusBox.style.display = 'block';
        } else {
            statusBox.style.display = 'none';
        }
    }
}

solve();