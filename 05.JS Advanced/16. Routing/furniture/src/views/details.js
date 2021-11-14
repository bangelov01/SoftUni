import { html } from "../../node_modules/lit-html/lit-html.js";
import { getFurnitureById, deleteFurniture } from "../api/data.js";
import { createModal } from "../modals/modal.js"

const detailsTemplate = (item, isOwner, onDelete) => html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src="${item.img}" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>${item.make}</span></p>
                <p>Model: <span>${item.model}</span></p>
                <p>Year: <span>${item.year}</span></p>
                <p>Description: <span>${item.description}</span></p>
                <p>Price: <span>${item.price}</span></p>
                <p>Material: <span>${item.material}</span></p>
                <div style=${isOwner ? "display:inline-block" : "display:none"}>
                    <a href=${`/edit/${item._id}`} class="btn btn-info">Edit</a>
                    <a @click=${onDelete} href="javascript:void(0)" class="btn btn-red">Delete</a>
                </div>
            </div>
        </div>
`;

export async function detailsPage(ctx) {

    try {
        const itemId = ctx.params.id;
        const ownerId = sessionStorage.getItem("userId");
        const item = await getFurnitureById(itemId);
        ctx.render(detailsTemplate(item, ownerId == item._ownerId, onDelete));

        async function onDelete() {

            const confirmed = await createModal('Are you sure you want to delete this furniture?');
            console.log(confirmed);
            if (confirmed) {
                await deleteFurniture(itemId);
                ctx.page.redirect('/');
            }
        }
    } catch (error) {
        alert(error.message);
    }
}