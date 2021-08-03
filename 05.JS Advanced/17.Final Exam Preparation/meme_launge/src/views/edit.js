import { html } from "../../node_modules/lit-html/lit-html.js";
import { getMemesById, updateMeme } from "../api/data.js";
import { notify } from "../notifications/notification.js"

const updateTemplate = (item, onSubmit) => html`
        <section id="edit-meme">
            <form id="edit-form" @submit=${onSubmit}>
                <h1>Edit Meme</h1>
                <div class="container">
                    <label for="title">Title</label>
                    <input id="title" type="text" placeholder="Enter Title" name="title" .value=${item.title}>
                    <label for="description">Description</label>
                    <textarea id="description" placeholder="Enter Description" name="description">${item.description}</textarea>
                    <label for="imageUrl">Image Url</label>
                    <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${item.imageUrl}>
                    <input type="submit" class="registerbtn button" value="Edit Meme">
                </div>
            </form>
        </section>
`;

export async function editPage(ctx) {

    const id = ctx.params.id;
    const item = await getMemesById(id);

    ctx.render(updateTemplate(item, onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const title = formData.get("title");
        const description = formData.get("description");
        const imageUrl = formData.get("imageUrl");

        try {

            if (title == '' || description == '' || imageUrl == '') {
                throw new Error('One or more non-optional fields are empty!')
            }

            await updateMeme(item._id, { title, description, imageUrl });
            ctx.page.redirect(`/details/${item._id}`)

        } catch (error) {
            notify(error.message);
        }
    }
}