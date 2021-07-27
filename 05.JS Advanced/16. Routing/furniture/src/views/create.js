import { html } from "../../node_modules/lit-html/lit-html.js";
import { createFurniture } from "../api/data.js";

const createTemplate = (onSubmit, validationObject) => html`
<div class="row space-top">
            <div class="col-md-12">
                <h1>Create New Furniture</h1>
                <p>Please fill all fields.</p>
                ${validationObject.all ? html`<p style="color:red">${`*${validationObject.allMsg}`}</p>` : ""}
                ${validationObject.make ? html`<p style="color:red">${`*${validationObject.makeMsg}`}</p>` : ""}
                ${validationObject.model ? html`<p style="color:red">${`*${validationObject.modelMsg}`}</p>` : ""}
                ${validationObject.year ? html`<p style="color:red">${`*${validationObject.yearMsg}`}</p>` : ""}
                ${validationObject.description ? html`<p style="color:red">${`*${validationObject.descriptionMsg}`}</p>` : ""}
                ${validationObject.price ? html`<p style="color:red">${`*${validationObject.priceMsg}`}</p>` : ""}
                ${validationObject.img ? html`<p style="color:red">${`*${validationObject.imgMsg}`}</p>` : ""}
            </div>
        </div>
        <form @submit=${onSubmit}>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-make">Make *</label>
                        <input class=${"form-control" + setupClass(validationObject, validationObject.make)} id="new-make" type="text" name="make">
                    </div>
                    <div class="form-group has-success">
                        <label class="form-control-label" for="new-model">Model *</label>
                        <input class=${"form-control" + setupClass(validationObject, validationObject.model)} id="new-model" type="text" name="model">
                    </div>
                    <div class="form-group has-danger">
                        <label class="form-control-label" for="new-year">Year *</label>
                        <input class=${"form-control" + setupClass(validationObject, validationObject.year)} id="new-year" type="number" name="year">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-description">Description *</label>
                        <input class=${"form-control" + setupClass(validationObject, validationObject.description)} id="new-description" type="text" name="description">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-price">Price *</label>
                        <input class=${"form-control" + setupClass(validationObject, validationObject.price)} id="new-price" type="number" name="price">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-image">Image *</label>
                        <input class=${"form-control" + setupClass(validationObject, validationObject.img)} id="new-image" type="text" name="img">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-material">Material (optional)</label>
                        <input class="form-control" id="new-material" type="text" name="material">
                    </div>
                    <input type="submit" class="btn btn-primary" value="Create" />
                </div>
            </div>
        </form>
`;


function setupClass(validationObject, value) {

    if (Object.keys(validationObject).length == 0) {
        return "";
    }
    if (!value) {
        return " is-valid";
    } else {
        return " is-invalid"
    }
}

export async function createPage(ctx) {

    ctx.render(createTemplate(onSubmit,{}));

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const body = [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v.trim() }), {});
        const validationObject = {};
        
        if (body.make.length < 4) {
            validationObject.make = true;
            validationObject.makeMsg = "Make must be at least 4 symbols long!";
        }
        if (body.model.length < 4) {
            validationObject.model = true;
            validationObject.modelMsg = "Model must be at least 4 symbols long!";
        }
        if (body.year < 1950 || body.year > 2050 || body.year == '') {
            validationObject.year = true;
            validationObject.yearMsg = "The year must be between 1950 and 2050!";
        }
        if (body.description.length <= 10) {
            validationObject.description = true;
            validationObject.descriptionMsg = "The description must be more than 10 symbols!";
        }
        if (body.price < 0 || body.price == '') {
            validationObject.price = true;
            validationObject.priceMsg = "Price must be a positive number!";
        }
        if (body.img.length == 0) {
            validationObject.img = true;
            validationObject.imgMsg = "Image URL is required!";
        }

        ctx.render(createTemplate(onSubmit, validationObject))

        if (Object.keys(validationObject).length == 0) {

            try {
                await createFurniture(body);
                ctx.page.redirect('/')

            } catch (error) {
                alert(error.message)
            }
        }
    }
}