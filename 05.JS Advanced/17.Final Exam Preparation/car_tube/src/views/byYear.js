import { html } from "../../node_modules/lit-html/lit-html.js";
import { search } from "../api/data.js";

const byYearTemplate = (cars, onSearch, year) => html`
        <section id="search-cars">
            <h1>Filter by year</h1>

            <div class="container">
                <input id="search-input" type="text" name="search" .value=${year || ''} placeholder="Enter desired production year">
                <button @click=${onSearch} class="button-list">Search</button>
            </div>

            <h2>Results:</h2>
            <div class="listings">

                <!-- Display all records -->
                ${cars.length == 0 ? emptyTemplate : cars.map(listingTemplate)}
                
            </div>
        </section>
`;

const listingTemplate = (car) => html`
                <div class="listing">
                    <div class="preview">
                        <img src=${car.imageUrl}>
                    </div>
                    <h2>${car.brand} ${car.model}</h2>
                    <div class="info">
                        <div class="data-info">
                            <h3>Year: ${car.year}</h3>
                            <h3>Price: ${car.price} $</h3>
                        </div>
                        <div class="data-buttons">
                            <a href=${`/details/${car._id}`} class="button-carDetails">Details</a>
                        </div>
                    </div>
                </div>
`;

const emptyTemplate = html`
<p class="no-cars"> No results.</p>
`;

export async function byYearPage(ctx) {
    const year = Number(ctx.querystring.split('=')[1]);
    const cars = Number.isNaN(year) ? '' : await search(year);
    console.log(cars);
    ctx.render(byYearTemplate(cars, onSearch, year));

    function onSearch() {
        const query = Number(document.getElementById("search-input").value);
        ctx.page.redirect(`/byYear?query=` + query);
    }
}