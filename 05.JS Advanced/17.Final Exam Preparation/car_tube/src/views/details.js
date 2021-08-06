import { html } from "../../node_modules/lit-html/lit-html.js";
import { getCarById, deleteCar} from "../api/data.js";

const detailsTemplate = (car, onDelete, isOwner) => html`
        <section id="listing-details">
            <h1>Details</h1>
            <div class="details-info">
                <img src=${car.imageUrl}>
                <hr>
                <ul class="listing-props">
                    <li><span>Brand:</span>${car.brand}</li>
                    <li><span>Model:</span>${car.model}</li>
                    <li><span>Year:</span>${car.year}</li>
                    <li><span>Price:</span>${car.price}$</li>
                </ul>

                <p class="description-para">${car.description}</p>
                ${isOwner ? buttonsTemplate(car, onDelete) : ''}
            </div>
        </section>
`;

const buttonsTemplate = (car, onDelete) => html`
                <div class="listings-buttons">
                    <a href=${`/edit/${car._id}`} class="button-list">Edit</a>
                    <a @click=${onDelete} href="javascript:void(0)" class="button-list">Delete</a>
                </div>
`;

export async function detailsPage(ctx) {
    
    const userId = sessionStorage.getItem("userId");
    try {
        const userCar = await getCarById(ctx.params.id);
        ctx.render(detailsTemplate(userCar, onDelete, userId == userCar._ownerId));

        async function onDelete() {
            await deleteCar(userCar._id);
            ctx.page.redirect("/allListings");
        }
    } catch (error) {
        alert(error.message)
    }
}