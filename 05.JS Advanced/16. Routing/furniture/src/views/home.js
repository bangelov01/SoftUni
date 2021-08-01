import { html } from "../../node_modules/lit-html/lit-html.js";
import { getFurnitures } from "../api/data.js";

const homeTemplate = (furnitures, searchParam, onSearch) => html`
<div class="row space-top">
            <div class="col-md-12">
                <h1>Welcome to Furniture System</h1>
                <p>Select furniture from the catalog to view details.</p>
                <div style="float:left">
                    <input id="searchInput" name="search" type="text" style="font-size: 20px" .value=${searchParam != undefined ? searchParam : ""} placeholder="Search...">
                    <button @click=${onSearch} style="font-size: 20px">Search</button>
                </div>
            </div>
        </div>
        <div class="row space-top">  
            ${furnitures.length > 0 ? furnitures.map(itemTemplate) : html`<h2 class="col-md-12">No furniture found!</h2>`}
        </div>
`;

const itemTemplate = (item) => html`
<div class="col-md-4">
    <div class="card text-white bg-primary">
        <div class="card-body">
                <img src=${item.img} />
                <p>${item.description}</p>
                <footer>
                    <p>Price: <span>${item.price} $</span></p>
                </footer>
                <div>
                    <a href=${`/details/${item._id}`} class="btn btn-info">Details</a>
                </div>
        </div>
    </div>
</div>
`;

export async function homePage(ctx) {
    try {
        const searchParam = ctx.querystring.split("=")[1];

        const furnitures = await getFurnitures(searchParam);
        ctx.render(homeTemplate(furnitures, searchParam, onSearch));

        function onSearch(e) {
            const searchValue = encodeURIComponent(document.getElementById("searchInput").value);
            ctx.page.redirect(`/?search=${searchValue}`)
        }

    } catch (error) {
        alert(error.message);
    } 
}