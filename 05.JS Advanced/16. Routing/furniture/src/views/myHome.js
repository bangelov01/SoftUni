import { html } from "../../node_modules/lit-html/lit-html.js";
import { getUserFurniture } from "../api/data.js";

const myHomeTemplate = (furnitures) => html`
<div class="row space-top">
            <div class="col-md-12">
                <h1>My Furniture</h1>
                <p>This is a list of your publications.</p>
                <h2 style=${furnitures.length > 0 ? "display:none" : "display:block"}>You don't have any furnitures! Create some!</h2>
            </div>
        </div>
        <div class="row space-top">  
            ${furnitures.map(itemTemplate)}   
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

export async function myHomePage(ctx) {
    try {
        const userId = sessionStorage.getItem("userId");
        const furnitures = await getUserFurniture(userId);
        ctx.render(myHomeTemplate(furnitures));
    } catch (error) {
        ctx.render(myHomeTemplate([]));
    } 
}