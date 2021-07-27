import { html } from "../../node_modules/lit-html/lit-html.js";
import { getFurnitureById, updateFurniture } from "../api/data.js";

const updateTemplate = (item, onSubmit) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Edit Furniture</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-make">Make</label>
                <input class="form-control" id="new-make" type="text" name="make" .value=${item.make}>
            </div>
            <div class="form-group has-success">
                <label class="form-control-label" for="new-model">Model</label>
                <input class="form-control" id="new-model" type="text" name="model" .value=${item.model}>
            </div>
            <div class="form-group has-danger">
                <label class="form-control-label" for="new-year">Year</label>
                <input class="form-control" id="new-year" type="number" name="year" .value=${item.year}>
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-description">Description</label>
                <input class="form-control" id="new-description" type="text" name="description"
                    .value=${item.description}>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-price">Price</label>
                <input class="form-control" id="new-price" type="number" name="price" .value=${item.price}>
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-image">Image</label>
                <input class="form-control" id="new-image" type="text" name="img" .value=${item.img}>
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class="form-control" id="new-material" type="text" name="material" .value=${item.material}>
            </div>
            <input type="submit" class="btn btn-info" value="Edit" />
        </div>
    </div>
</form>
`;

export async function editPage(ctx) {

    try {
        const id = ctx.params.id;
        const item = await getFurnitureById(id);

        ctx.render(updateTemplate(item, onSubmit));

        async function onSubmit(e) {
            e.preventDefault();

            const formData = new FormData(e.target);
            const body = [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v.trim() }), {});

            if (Object.entries(body).filter(([k, v]) => k != 'material').some(([k, v]) => v == '')) {
                return alert('One or more non-optional fields are empty!')
            }
            
            await updateFurniture(item._id, body);
            ctx.page.redirect('/')
        }
    } catch (error) {
        alert(error.message);
    }
}