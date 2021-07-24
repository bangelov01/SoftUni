import {html, render} from "../node_modules/lit-html/lit-html.js";

function solve() {

    document.querySelector('form').addEventListener('submit', (e) => {
        e.preventDefault();
    
        const formData = new FormData(e.target);
        const input = formData.get('towns');
        const cities = input.split(', ').map(t => t.trim());

        render(ulTemplate(cities), document.getElementById('root'));
    });

    const ulTemplate = (cities) => html`
        <ul>
            ${cities.map(c => html`<li>${c}</li>`)}
        </ul>
    `;
}

solve();