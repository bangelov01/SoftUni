import {createRecipe} from "../api/data.js"

export function setupCreate(section, navigation) {

    section.querySelector(`form`).addEventListener(`submit`, async(e) => {
        e.preventDefault();
    
        const formData = new FormData(e.target);

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
    
        const recipe = await createRecipe(body);
        e.target.reset();
        navigation.goTo('details', recipe._id);
    });

    return showCreate;

    function showCreate() {
        return section;
    }
}