import {getRecipeById, editRecipeById} from "../api/data.js"

export function setupEdit(section, navigation) {

    section.querySelector(`form`).addEventListener(`submit`, async(e) => {
        e.preventDefault();
    
        const formData = new FormData(e.target); 
        const id = e.target.dataset.id;
        
        const body = {
            name: formData.get(`name`),
            img: formData.get(`img`),
            ingredients: formData.get(`ingredients`)
                .split(`\n`)
                .map(line => line.trim())
                .filter(line => line != ``),
            steps: formData.get(`steps`)
                .split(`\n`)
                .map(line => line.trim())
                .filter(line => line != ``)
        };


        await editRecipeById(id, body);
        e.target.reset();
        navigation.goTo('details', id);
    });

    return showEdit;

    async function showEdit(id) {

        const recipe = await getRecipeById(id);
    
        section.querySelector('form').setAttribute('data-id', id);
        section.querySelector(`[name="name"]`).value = recipe.name;
        section.querySelector(`[name="img"]`).value = recipe.img;
        section.querySelector(`[name="ingredients"]`).value = recipe.ingredients.join('\n');
        section.querySelector(`[name="steps"]`).value = recipe.steps.join('\n');

        return section;
    }
}

