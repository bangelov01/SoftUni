import { html } from "../../node_modules/lit-html/lit-html.js";
import { getMemesById, deleteMeme } from "../api/data.js";

const detailsTemplate = (item, isOwner, onDelete) => html`
        <section id="meme-details">
            <h1>Meme Title: ${item.title}
        
            </h1>
            <div class="meme-details">
                <div class="meme-img">
                    <img alt="meme-alt" src=${item.imageUrl}>
                </div>
                <div class="meme-description">
                    <h2>Meme Description</h2>
                    <p>
                        ${item.description}
                    </p>
                    ${isOwner ? buttonsTemplate(onDelete, item) : ""}
                </div>
            </div>
        </section>
`;

const buttonsTemplate = (onDelete, item) => html`
                    <a class="button warning" href="/edit/${item._id}">Edit</a>
                    <button @click=${onDelete} class="button danger" href="javascript:void(0)">Delete</button>
`;

export async function detailsPage(ctx) {

    const itemId = ctx.params.id;
    const ownerId = sessionStorage.getItem("userId");
    const item = await getMemesById(itemId);
    ctx.render(detailsTemplate(item, ownerId == item._ownerId, onDelete));

    async function onDelete() {

        const confirmed = confirm('Are you sure you want to delete this furniture?')
        if (confirmed) {
            await deleteMeme(itemId);
            ctx.page.redirect('/allMemes');
        }
    }
}